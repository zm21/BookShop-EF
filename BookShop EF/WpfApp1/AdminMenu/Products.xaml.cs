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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl, IChildWindow
    {
        private IBLLClass _bll;
        public Products()
        {
            InitializeComponent();
            _bll = new BLLClass();
            LoadProducts();
        }
        public void LoadProducts()
        {
            dataGrid.ItemsSource = _bll.GetProducts();
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct(grid, this);
            addProduct.OpenMsg += ShowMsg;
            grid.Children.Add(addProduct);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var prod = dataGrid.SelectedItem as ProductDTO;
                EditProduct editProduct = new EditProduct(grid, this, prod);
                editProduct.OpenMsg += ShowMsg;
                grid.Children.Add(editProduct);
            }
            else
                ShowMsg("Editing a product", "First select product");
        }
    }
}
