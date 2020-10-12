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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : UserControl, IChildWindow
    {
        IBLLClass _bll;
        Grid parent;
        Books books;
        public AddBook(Grid parent, Books books)
        {
            InitializeComponent();
            _bll = new BLLClass();
            this.books = books;
            this.parent = parent;
            LoadCBoxex();
        }
        
        private void LoadCBoxex()
        {
            comboBox_Author.ItemsSource = _bll.GetAuthors();
            comboBox_Author.DisplayMemberPath = nameof(AuthorDTO.FullName);
            comboBox_genre.ItemsSource = _bll.GetGenres();
            comboBox_genre.DisplayMemberPath = nameof(GenreDTO.Name);
            comboBox_publisher.ItemsSource = _bll.GetPublishers();
            comboBox_publisher.DisplayMemberPath = nameof(PublisherDTO.Name);
            comboBox_SequelTo.ItemsSource = _bll.GetBooks();
            comboBox_SequelTo.DisplayMemberPath = nameof(BookDTO.Name);
        }

        public event MessageDelegate OpenMsg;

        event ClosingDelegate IChildWindow.Closing
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }


        public void Close()
        {
            books.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void IChildWindow.Close()
        {
            throw new NotImplementedException();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox_Author.SelectedItem==null || comboBox_genre.SelectedItem == null || comboBox_publisher.SelectedItem==null || string.IsNullOrEmpty(txtbox_BookName.Text))
            {
                ShowMsg("Adding error!", "First fill all fields!");
            }
            else
            {
                BookDTO bookDTO = new BookDTO();
                bookDTO.Name = txtbox_BookName.Text;
                bookDTO.PagesCount = numeric_pagescount.Value;
                bookDTO.PublishYear = datepicker_publishYear.SelectedDate.Value.Year;
                bookDTO.AuthorId = (comboBox_Author.SelectedItem as AuthorDTO).Id;
                bookDTO.GenreId = (comboBox_genre.SelectedItem as GenreDTO).Id;
                bookDTO.PublisherId = (comboBox_publisher.SelectedItem as PublisherDTO).Id;
                if (comboBox_SequelTo.SelectedItem != null)
                    bookDTO.SequelToId = (comboBox_SequelTo.SelectedItem as BookDTO).Id;
                _bll.AddBook(bookDTO);
                books.LoadBooks();
                ShowMsg("Adding", "Book added!");
                this.Close();
            }
        }
    }
}
