using ProjectPRN212.Models;
using System.Windows;

namespace ProjectPRN212.GUI.Page_Admin
{
    /// <summary>
    /// Interaction logic for CreateNewProduct.xaml
    /// </summary>
    public partial class CreateNewProduct : Window
    {
        public CreateNewProduct()
        {
            InitializeComponent();
            LoadCate();

        }

        private void LoadCate()
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                var categories = context.ProductCategories
                                         .Select(e => new
                                         {
                                             CategoryId = e.CategoryId,
                                             CategoryName = e.CategoryName
                                         }).Distinct();
                cmbCategory.ItemsSource = categories.ToList();
                cmbCategory.DisplayMemberPath = "CategoryName";
                cmbCategory.SelectedValuePath = "CategoryId";

                cmbCategory.SelectedIndex = 0;
            }
        }

            private void CreateButton_Click(object sender, RoutedEventArgs e)
            {
            string productName = txtProductName.Text;
            string priceText = txtPrice.Text;
            string quantityText = txtQuantity.Text;
            int categoryId = (int)cmbCategory.SelectedValue;
            string thumbnail = txtThumbnail.Text;
            string summary = txtSummary.Text;
            string productDetail = txtProductDetail.Text;

            if (string.IsNullOrEmpty(productName) ||
                string.IsNullOrEmpty(priceText) ||
                string.IsNullOrEmpty(quantityText) ||
                string.IsNullOrEmpty(thumbnail) ||
                string.IsNullOrEmpty(summary) ||
                string.IsNullOrEmpty(productDetail))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin ");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Vui lòng giá tiền nhập số tiền ");
                return;
            }

            if (!int.TryParse(quantityText, out int quantity))
            {
                MessageBox.Show("Invalid quantity format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Product newProduct = new Product
            {
                ProductName = productName,
                OriginalPrice = float.Parse(priceText),
                SalePrice = float.Parse(priceText),
                Quantity = quantity,
                CategoryId = categoryId,
                Thumbnail = thumbnail,
                ProductImage = thumbnail,
                Summary = summary,
                ProductDetail = productDetail,
                ProductStatus =  true , 
                CreateDate = DateTime.Now,
                IsDeleted = false
            };

            using (ShopNewContext context = new ShopNewContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }

            MessageBox.Show("Product created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Visibility = Visibility.Collapsed;
            ManagementProduct ManagementProduct = new ManagementProduct();
            ManagementProduct.ShowDialog();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            ManagementProduct ManagementProduct = new ManagementProduct();
            ManagementProduct.ShowDialog();
            this.Close();
        }
    }
}
