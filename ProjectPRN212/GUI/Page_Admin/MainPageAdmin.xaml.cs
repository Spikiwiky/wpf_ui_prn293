using Microsoft.Extensions.DependencyInjection;
using ProjectPRN212.Service;
using System.Windows;
using static ProjectPRN212.Login_Register.Login;


namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class MainPageAdmin : Window
    {
        private readonly UserApiService _userService;
        public MainPageAdmin(UserApiService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have access to your Startup DI container:
            var serviceProvider = new Startup().ConfigureServices();
            var productService = serviceProvider.GetRequiredService<AdminProductApiService>();

            ProductManagementWindow window = new ProductManagementWindow(productService);
            window.ShowDialog();
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
      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;

            ManagementUser managementUserWindow = new ManagementUser(_userService);
            managementUserWindow.ShowDialog();

            this.Close();
        }
    }
}
