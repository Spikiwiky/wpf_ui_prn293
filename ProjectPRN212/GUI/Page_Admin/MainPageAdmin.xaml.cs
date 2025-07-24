using ProjectPRN212.GUI.Login_Register;
using System.Windows;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Page_Admin
{
    /// <summary>
    /// Interaction logic for MainPageAdmin.xaml
    /// </summary>
    public partial class MainPageAdmin : Window
    {
        public MainPageAdmin()
        {
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Profile profile = new Profile();
            profile.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.staffSession = null;
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
            this.Close();
        }
    }
}
