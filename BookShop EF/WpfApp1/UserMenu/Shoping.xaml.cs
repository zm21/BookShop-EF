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
    /// Interaction logic for Shoping.xaml
    /// </summary>
    public partial class Shoping : UserControl, IChildWindow
    {
        private IBLLClass _bll;
        UserDTO userDTO;
        public Shoping(UserDTO userDTO)
        {
            InitializeComponent();
            _bll = new BLLClass();
            this.userDTO = userDTO;
            LoadBooks();
        }

        public void LoadBooks()
        {
            dataGrid.ItemsSource = userDTO.Id==0 ? _bll.GetAllSales() : _bll.GetSales(userDTO);
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);
    }
}
