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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : UserControl, IChildWindow
    {
        Grid parent;
        Products products;
        IBLLClass _bll;
        public AddProduct(Grid parent, Products products)
        {
            InitializeComponent();
            this.parent = parent;
            this.products = products;
            _bll = new BLLClass();
            comboBox_Book.ItemsSource = _bll.GetBooksForProducts();
            comboBox_Book.DisplayMemberPath = nameof(BookDTO.Name);
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
            products.Visibility = Visibility.Visible;
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
            if (comboBox_Book.SelectedItem == null)
            {
                ShowMsg("Adding error!", "First fill all fields!");
            }
            else
            {
                ProductDTO productDTO = new ProductDTO();
                productDTO.BookId = (comboBox_Book.SelectedItem as BookDTO).Id;
                productDTO.Cost = numeric_cost.Value;
                productDTO.SellingPrice = numeric_sellingprice.Value;
                productDTO.Count = numeric_count.Value;
                productDTO.Discount = numeric_discount.Value;   
                _bll.AddProduct(productDTO);
                products.LoadProducts();
                ShowMsg("Adding", "Product added!");
                this.Close();
            }
        }
    }
}