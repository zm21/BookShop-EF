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
    /// Interaction logic for Publishers.xaml
    /// </summary>
    public partial class Publishers : UserControl, IChildWindow
    {
        private IBLLClass _bll;
        public Publishers()
        {
            InitializeComponent();
            _bll = new BLLClass();
            LoadPublishers();
        }
        public void LoadPublishers()
        {
            dataGrid.ItemsSource = _bll.GetPublishers();
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPublisher addPublisher = new AddPublisher(grid, this);
            addPublisher.OpenMsg += ShowMsg;
            grid.Children.Add(addPublisher);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                PublisherDTO publisherDTO = dataGrid.SelectedItem as PublisherDTO;
                EditPublisher edit = new EditPublisher(grid, this, publisherDTO);
                edit.OpenMsg += ShowMsg;
                grid.Children.Add(edit);
                
            }
            else
                ShowMsg("Editing a publisher", "First select publisher");
        }
    }
}
