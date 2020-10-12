using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for SearchBooks.xaml
    /// </summary>
    public partial class SearchBooks : UserControl, IChildWindow
    {
        private IBLLClass _bll;
        UserDTO user;
        public SearchBooks(UserDTO user)
        {
            InitializeComponent();
            _bll = new BLLClass();
            this.user = user;
            var genres = _bll.GetGenres().ToList();
            genres.Insert(0, new GenreDTO() { Id = 0, Name = "All genres" });
            comboBox_genre.ItemsSource = genres;
            comboBox_genre.DisplayMemberPath = nameof(GenreDTO.Name);
            comboBox_genre.SelectedIndex = 0;
            LoadBooks();
        }

        public void LoadBooks()
        {
            dataGrid.ItemsSource = _bll.GetBookProduct();
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            var genre = comboBox_genre.SelectedItem as GenreDTO;
            if(!string.IsNullOrEmpty(txtbox_search.Text))
            {
                string str = txtbox_search.Text;
                if (genre.Id == 0)
                    dataGrid.ItemsSource = _bll.GetBookProduct().Where(b => b.Name.Contains(str) || b.Author.Contains(str) || b.Publisher.Contains(str));
                else
                    dataGrid.ItemsSource = _bll.GetBookProduct().Where(b => (b.Name.Contains(str) || b.Author.Contains(str) || b.Publisher.Contains(str)) && b.Genre == genre.Name);
            }
            else
            {
                if (genre.Id == 0)
                    dataGrid.ItemsSource = _bll.GetBookProduct();
                else
                    dataGrid.ItemsSource = _bll.GetBookProduct().Where(b=> b.Genre == genre.Name);
            }
        }

        private void ButtonReserv_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var bookproduct = dataGrid.SelectedItem as BookProductDTO;
                if (bookproduct.Count != 0)
                {
                    if(!_bll.IsUserReservBook(bookproduct, user))
                    {
                        _bll.ReservBook(bookproduct, user);
                        ShowMsg("Reserving a book", "The book was successfully reserved!");
                        this.Close();
                    }
                    else
                        ShowMsg("Reserving a book", "You already reserv this book");
                }
                else
                    ShowMsg("Reserving a book", "The book is not available");
            }
            else
                ShowMsg("Reserving a book", "First select book");
        }

        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem!=null)
            {
                var bookproduct = dataGrid.SelectedItem as BookProductDTO;
                if(bookproduct.Count!=0)
                {
                    _bll.BuyBook(bookproduct, user);
                    ShowMsg("Buying a book", "The book was successfully purchased!");
                    this.Close();
                }
                else
                    ShowMsg("Buying a book", "The book is not available");
            }
            else
                ShowMsg("Buying a book", "First select book");
        }
    }
}
