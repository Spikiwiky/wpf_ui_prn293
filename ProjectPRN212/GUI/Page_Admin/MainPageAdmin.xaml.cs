using Microsoft.Extensions.DependencyInjection;
using ProjectPRN212.Service;
using System.Windows;


namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class MainPageAdmin : Window
    {
        public MainPageAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have access to your Startup DI container:
            var serviceProvider = new Startup().ConfigureServices();
            var productService = serviceProvider.GetRequiredService<AdminProductApiService>();

            ProductManagementWindow window = new ProductManagementWindow(productService);
            window.ShowDialog();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Handle "Manage Users" button click here
            MessageBox.Show("Manage Users Clicked");
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            // Handle Profile button click
            MessageBox.Show("Profile Clicked");
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.RoleName = null;
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
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
            this.Visibility = Visibility.Collapsed;
            ManagementUser ManagementUser = new ManagementUser();
            ManagementUser.ShowDialog();
            // Handle logout logic
            this.Close();
        }
    }
}
