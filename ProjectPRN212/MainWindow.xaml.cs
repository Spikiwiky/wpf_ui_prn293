using Microsoft.Extensions.DependencyInjection;
using ProjectPRN212.GUI.Cart;
using ProjectPRN212.GUI.Login_Register;
using ProjectPRN212.GUI.Order;
using ProjectPRN212.Login_Register;
using ProjectPRN212.Models;
using ProjectPRN212.Presentproduct;
using ProjectPRN212.Service;
using System.Windows;
using System.Windows.Media.Imaging;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckUserbtn();
            LoadNewProduct();
            //testApi();
        }

        private async void testApi()
        {
            var service = App.ServiceProvider.GetService<ProductApiService>();
            var products = await service.GetPagedProductsAsync(1, 10);
            MessageBox.Show(string.Join("\n", products.Select(p => $"{p.ProductId} - {p.Name} - {p.BasePrice:C}")));

        }

        private void LoadNewProduct()
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                Product latestProduct = context.Products
                                        .Where(p => p.ProductStatus == true)
                                        .OrderByDescending(p => p.CreateDate)
                                        .FirstOrDefault();

                if (latestProduct != null)
                {
                    LatestProductImage.Source = new BitmapImage(new Uri(latestProduct.Thumbnail, UriKind.RelativeOrAbsolute));
                    LatestProductName.Text = latestProduct.ProductName;
                    LatestProductPrice.Text = $"${latestProduct.SalePrice:F2}";
                    LatestProductDescription.Text = latestProduct.Summary;
                }
            }
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Login loginControl = new Login();
            loginControl.ShowDialog();
            this.Close();
        }

        private void CheckUserbtn()
        {
            if (ApplicationState.RoleName != null)
            {
                btnProfile.Visibility = Visibility.Visible;
                btnMyOrder.Visibility = Visibility.Visible;
                btnLogout.Visibility = Visibility.Visible;
                btn_Login.Visibility = Visibility.Collapsed;

            }
            else
            {
                btnLogout.Visibility = Visibility.Collapsed;
                btn_Login.Visibility = Visibility.Visible;
                btnProfile.Visibility = Visibility.Collapsed;
                btnMyOrder.Visibility = Visibility.Collapsed;

            }
        }



        private void btnPresentProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            PresentProduct presentProduct = new PresentProduct();
            presentProduct.ShowDialog();
            this.Close();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            Profile Profile = new Profile();
            Profile.ShowDialog();

            this.Close();

        }

        private void btnMyOrder_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            MyOrder MyOrder = new MyOrder();
            MyOrder.ShowDialog();
            this.Close();
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {


            this.Visibility = Visibility.Collapsed;
            Cart cartWindow = new Cart();
            cartWindow.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            ApplicationState.RoleName = null;
            CheckUserbtn();
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }

        private void BtnShowProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            PresentProduct presentProduct = new PresentProduct();
            presentProduct.ShowDialog();
            this.Close();

        }
    }

}