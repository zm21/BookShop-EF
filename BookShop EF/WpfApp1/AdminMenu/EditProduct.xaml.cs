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
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : UserControl, IChildWindow
    {
        Grid parent;
        Products products;
        ProductDTO productDTO;
        public EditProduct(Grid parent, Products products, ProductDTO productDTO)
        {
            InitializeComponent();
            this.parent = parent;
            this.products = products;
            this.productDTO = productDTO;
            numeric_cost.Value = (int)productDTO.Cost;
            numeric_sellingprice.Value = (int)productDTO.SellingPrice;
            numeric_count.Value = productDTO.Count;
            numeric_discount.Value = productDTO.Discount ?? 0;
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
            productDTO.Cost = numeric_cost.Value;
            productDTO.SellingPrice = numeric_sellingprice.Value;
            productDTO.Count = numeric_count.Value;
            productDTO.Discount = numeric_discount.Value;
            IBLLClass _bll = new BLLClass();
            _bll.EditProduct(productDTO);
            products.LoadProducts();
            ShowMsg("Editing", "Product edited!");
            products.Close();
            this.Close();
        }
    }
}
