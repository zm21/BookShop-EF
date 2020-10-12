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
    /// Interaction logic for AddPublisher.xaml
    /// </summary>
    public partial class AddPublisher : UserControl, IChildWindow
    {
        Grid parent;
        Publishers publishers;
        public AddPublisher(Grid parent, Publishers publishers)
        {
            InitializeComponent();
            this.parent = parent;
            this.publishers = publishers;
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
            publishers.Visibility = Visibility.Visible;
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
            if (string.IsNullOrEmpty(txtbox_PublisherName.Text))
            {
                ShowMsg("Adding error", "First fill all fields");
            }
            else
            {
                PublisherDTO publisherDTO = new PublisherDTO() { Name = txtbox_PublisherName.Text };
                IBLLClass bLLClass = new BLLClass();
                if (!bLLClass.IsExistPublisher(publisherDTO))
                {
                    bLLClass.AddPublisher(publisherDTO);
                    publishers.LoadPublishers();
                    ShowMsg("Adding", "Publisher added!");
                    this.Close();
                }
                else
                    ShowMsg("Adding error", "Such publisher already exists!");
            }
        }
    }
}