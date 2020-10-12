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
    /// Interaction logic for EditAuthor.xaml
    /// </summary>
    public partial class EditAuthor : UserControl, IChildWindow
    {
        Grid parent;
        Authors authors;
        AuthorDTO authorDTO;
        public EditAuthor(Grid parent, Authors authors, AuthorDTO authorDTO)
        {
            InitializeComponent();
            this.parent = parent;
            this.authors = authors;
            this.authorDTO = authorDTO;
            this.DataContext = authorDTO;
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
            //authors.FiltrCars();
            authors.Visibility = Visibility.Visible;
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
            if (string.IsNullOrEmpty(txtbox_FirstName.Text) || string.IsNullOrEmpty(txtbox_LastName.Text) || string.IsNullOrEmpty(txtbox_MiddleName.Text))
            {
                ShowMsg("Editing error", "First fill all fields");
            }
            else
            {
                IBLLClass bLLClass = new BLLClass();
                if (!bLLClass.IsExistAuthor(authorDTO))
                {
                    bLLClass.EditAuthor(authorDTO);
                    ShowMsg("Editing", "Author edited!");
                    authors.LoadAuthors();
                    authors.Close();
                    this.Close();
                }
                else
                    ShowMsg("Editing error", "Such author already exists!");
            }
        }
    }
}
