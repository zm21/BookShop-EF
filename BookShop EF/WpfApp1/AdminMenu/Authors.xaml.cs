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
    /// Interaction logic for Authors.xaml
    /// </summary>
    public partial class Authors : UserControl, IChildWindow
    {

        private IBLLClass _bll;
        public Authors()
        {
            InitializeComponent();
            _bll = new BLLClass();
            LoadAuthors();
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddAuthor addAuthor = new AddAuthor(grid, this);
            addAuthor.OpenMsg += ShowMsg;
            grid.Children.Add(addAuthor);
        }
        public void LoadAuthors()
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = _bll.GetAuthors();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                EditAuthor editAuthor = new EditAuthor(grid, this, dataGrid.SelectedItem as AuthorDTO);
                editAuthor.OpenMsg += ShowMsg;
                grid.Children.Add(editAuthor);
            }
            else
                ShowMsg("Editing a author", "First select author");
        }
    }
}
