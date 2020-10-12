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
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : UserControl, IChildWindow
    {
        private IBLLClass _bll;
        public Rating()
        {
            InitializeComponent();
            _bll = new BLLClass();

            List<BookDTO> booksDTOs = new List<BookDTO>();
            booksDTOs.Add(_bll.MostSalledBook());
            dataGrid_book.ItemsSource = booksDTOs;

            List<AuthorDTO> authorDTOs = new List<AuthorDTO>();
            authorDTOs.Add(_bll.MostWriterAuthor());
            dataGrid_author.ItemsSource = authorDTOs;

            List<GenreDTO> genreDTOs = new List<GenreDTO>();
            genreDTOs.Add(_bll.MostPopularGenre());
            dataGrid_genre.ItemsSource = genreDTOs;
        }

        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);

    }
}
