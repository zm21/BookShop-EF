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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : UserControl, IChildWindow
    {
        private IBLLClass _bll;
        public Books()
        {
            InitializeComponent();
            _bll = new BLLClass();
            LoadBooks();
        }

        public void LoadBooks()
        {
            dataGrid.ItemsSource = _bll.GetBooks();
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);

        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook(grid, this);
            addBook.OpenMsg += ShowMsg;
            grid.Children.Add(addBook);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                BookDTO bookDTO = dataGrid.SelectedItem as BookDTO;
                EditBook editBook = new EditBook(grid, this, bookDTO);
                editBook.OpenMsg += ShowMsg;
                grid.Children.Add(editBook);
            }
            else
                ShowMsg("Editing a book", "First select book");
        }
    }
  
}
