using ProjectPRN212.Models;
using System.Linq;
using System.Windows;

namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class UpdateProduct : Window
    {
        private int productId;

        public UpdateProduct(int idProductToUpdate)
        {
            InitializeComponent();
            productId = idProductToUpdate;
            LoadInfor();
        }

        private void LoadInfor()
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId);

                if (product != null)
                {
                    txtProductName.Text = product.ProductName;
                    txtPrice.Text = product.SalePrice.ToString();
                    numericQuantity.Value = product.Quantity;
                    txtSummary.Text = product.Summary;
                    txtProductDetail.Text = product.ProductDetail;
                }
                else
                {
                    MessageBox.Show("Product not found");
                    Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            ManagementProduct ManagementProduct = new ManagementProduct();
            ManagementProduct.ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId);

                if (product != null)
                {
                    product.ProductName = txtProductName.Text;
                    product.SalePrice = float.Parse(txtPrice.Text);
                    product.Quantity = numericQuantity.Value ?? 0;
                    product.Summary = txtSummary.Text;
                    product.ProductDetail = txtProductDetail.Text;

                    context.SaveChanges();
                    MessageBox.Show("Product updated successfully!");
                    this.Visibility = Visibility.Collapsed;
                    ManagementProduct ManagementProduct = new ManagementProduct();
                    ManagementProduct.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Product not found");
                }
            }
        }
    }
}
