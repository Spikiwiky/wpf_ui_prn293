using ProjectPRN212.GUI.Login_Register;
using ProjectPRN212.Models;
using System.Windows;
using System.Windows.Controls;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Page_Admin
{
    /// <summary>
    /// Interaction logic for ManagementUser.xaml
    /// </summary>
    public partial class ManagementUser : Window
    {
        public ManagementUser()
        {

            InitializeComponent();
            loadCustomer();
        }

        private void loadCustomer()
        {
            using (ShopNewContext context = new ShopNewContext())
            {


                var customers = context.Customers.ToList();

                dgUsers.ItemsSource = customers;
            }
        }

        private void btnManageProduct_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Collapsed;
            //ManagementProduct ManagementProduct = new ManagementProduct();
            //ManagementProduct.ShowDialog();
            //this.Close();
        }
        private void lockUserButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Customer customer = button.DataContext as Customer;
                if (customer != null)
                {
                    customer.Status = !customer.Status;

                    using (ShopNewContext context = new ShopNewContext())
                    {
                        Customer dbCustomer = context.Customers.FirstOrDefault(p => p.CustomerId == customer.CustomerId);
                        if (dbCustomer != null)
                        {
                            dbCustomer.Status = false;
                            context.SaveChanges();
                            MessageBox.Show($"Bạn đã khóa acc:  {dbCustomer.Fullname}!");
                        }
                    }
                }
            }
            loadCustomer();
        }
        private void UnlockUserButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Customer customer = button.DataContext as Customer;
                if (customer != null)
                {
                    customer.Status = !customer.Status;

                    using (ShopNewContext context = new ShopNewContext())
                    {
                        Customer dbCustomer = context.Customers.FirstOrDefault(p => p.CustomerId == customer.CustomerId);
                        if (dbCustomer != null)
                        {
                            dbCustomer.Status = true;
                            context.SaveChanges();
                            MessageBox.Show($"Bạn đã mở khóa acc:  {dbCustomer.Fullname}!");
                        }
                    }
                }
            }
            loadCustomer();
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

            ApplicationState.RoleName = null;
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }
    }
}
