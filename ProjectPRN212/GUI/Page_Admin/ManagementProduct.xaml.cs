using ProjectPRN212.GUI.Login_Register;
using ProjectPRN212.Models;
using System.Windows;
using System.Windows.Controls;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Page_Admin
{
    /// <summary>
    /// Interaction logic for ManagementProduct.xaml
    /// </summary>
    public partial class ManagementProduct : Window
    {
        public ManagementProduct()
        {
            InitializeComponent();
            loadProduct();
        }

        private void loadProduct()
        {
            using (ShopNewContext context = new ShopNewContext())
            {


                List<Product> products = context.Products.Where(e => e.IsDeleted == false).ToList();

                dgProducts.ItemsSource = products;
            }
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Profile profile = new Profile();
            profile.ShowDialog();
            this.Close();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Product product = button.DataContext as Product;
                if (product != null)
                {

                    using (ShopNewContext context = new ShopNewContext())
                    {
                        Product dbProduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                        if (dbProduct != null)
                        {
                            int idProductToUpdate = dbProduct.ProductId;
                            this.Visibility = Visibility.Collapsed;
                            UpdateProduct UpdateProduct = new UpdateProduct(idProductToUpdate);
                            UpdateProduct.ShowDialog();
                            this.Close();
                        }
                    }
                }
            }


        }
        private void HideProduct_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Product product = button.DataContext as Product;
                if (product != null)
                {
                    product.ProductStatus = !product.ProductStatus;

                    using (ShopNewContext context = new ShopNewContext())
                    {
                        Product dbProduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                        if (dbProduct != null)
                        {
                            dbProduct.ProductStatus = false;
                            context.SaveChanges();
                            MessageBox.Show($"Bạn đã ẩn {dbProduct.ProductName}!");
                        }
                    }
                }
            }
            loadProduct();
        }

        private void ShowProduct_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Product product = button.DataContext as Product;
                if (product != null)
                {
                    product.ProductStatus = !product.ProductStatus;

                    using (ShopNewContext context = new ShopNewContext())
                    {
                        Product dbProduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                        if (dbProduct != null)
                        {
                            dbProduct.ProductStatus = true;
                            context.SaveChanges();
                            MessageBox.Show($"Bạn đã hiển thị  {dbProduct.ProductName}!");
                        }
                    }
                }
            }
            loadProduct();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                Product product = button.DataContext as Product;
                if (product != null)
                {

                    using (ShopNewContext context = new ShopNewContext())
                    {
                        Product dbProduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                        if (dbProduct != null)
                        {
                            dbProduct.IsDeleted = true;
                            context.SaveChanges();

                            MessageBox.Show($"Bạn đã  xoa :   {dbProduct.ProductName}!");
                        }
                    }
                }
            }
            loadProduct();
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.staffSession = null;
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }

        private void btn_createNewProduct_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            CreateNewProduct CreateNewProduct = new CreateNewProduct();
            CreateNewProduct.ShowDialog();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            ManagementUser ManagementUser = new ManagementUser();
            ManagementUser.ShowDialog();
            this.Close();
        }
    }
}
