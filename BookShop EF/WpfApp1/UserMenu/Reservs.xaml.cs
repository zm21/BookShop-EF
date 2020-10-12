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
    /// Interaction logic for Reservs.xaml
    /// </summary>
    public partial class Reservs : UserControl, IChildWindow
    {
        private IBLLClass _bll;
        UserDTO userDTO;
        public Reservs(UserDTO userDTO)
        {
            InitializeComponent();
            _bll = new BLLClass();
            this.userDTO = userDTO;
            LoadBooks();
        }

        public void LoadBooks()
        {
            dataGrid.ItemsSource = _bll.GetReservs(userDTO);
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var res = dataGrid.SelectedItem as ReservDTO;
                _bll.CancelReserv(res);
                ShowMsg("Canceling reserv", "Reserv was canceled");
                this.Close();
            }
            else
                ShowMsg("Canceling reserv", "First select reserv");
        }

        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var res = dataGrid.SelectedItem as ReservDTO;
                _bll.BuyFromReserv(res);
                ShowMsg("Buying a book", "The book was successfully purchased!");
                this.Close();
            }
            else
                ShowMsg("Buying a book", "First select reserv");
        }
    }
}