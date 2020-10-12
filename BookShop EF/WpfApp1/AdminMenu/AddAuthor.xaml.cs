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
    /// Interaction logic for AddAuthor.xaml
    /// </summary>
    public partial class AddAuthor : UserControl, IChildWindow
    {
        Grid parent;
        Authors authors;
        public AddAuthor(Grid parent, Authors authors)
        {
            InitializeComponent();
            this.parent = parent;
            this.authors = authors;
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
            if(string.IsNullOrEmpty(txtbox_FirstName.Text)|| string.IsNullOrEmpty(txtbox_LastName.Text) || string.IsNullOrEmpty(txtbox_MiddleName.Text))
            {
                ShowMsg("Adding error", "First fill all fields");
            }
            else
            {
                AuthorDTO authorDTO = new AuthorDTO() { FirstName = txtbox_FirstName.Text, LastName = txtbox_LastName.Text, MiddleName = txtbox_MiddleName.Text };
                IBLLClass bLLClass = new BLLClass();
                if (!bLLClass.IsExistAuthor(authorDTO))
                {
                    bLLClass.AddAuthor(authorDTO);
                    authors.LoadAuthors();
                    ShowMsg("Adding", "Author added!");
                    this.Close();
                }
                else
                    ShowMsg("Adding error", "Such author already exists!");
            }
        }
    }
}
