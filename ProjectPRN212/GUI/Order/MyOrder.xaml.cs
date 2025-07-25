using ProjectPRN212.CartModels;
using System.Windows;
using ProjectPRN212.Models;
using static ProjectPRN212.Login_Register.Login;
using System.Windows.Controls;
using ProjectPRN212.Presentproduct;
using ProjectPRN212.Login_Register;

namespace ProjectPRN212.GUI.Order
{

    public partial class MyOrder : Window
    {
        public List<ProjectPRN212.Models.Order> listOrder = new List<ProjectPRN212.Models.Order>();
        string currentUserEmail = ApplicationState.CurrentUserSessionEmail;
        public MyOrder()
        {
            InitializeComponent();
            LoadOrderByCustomer();
            CheckUserbtn();
        }
        private void CheckUserbtn()
        {
            if (ApplicationState.RoleName != null)
            {
                btnProfile.Visibility = Visibility.Visible;
                //  btnMyOrder.Visibility = Visibility.Visible;
                btnLogout.Visibility = Visibility.Visible;
                btn_Login.Visibility = Visibility.Collapsed;

            }
            else
            {
                btnLogout.Visibility = Visibility.Collapsed;
                btn_Login.Visibility = Visibility.Visible;
                btnProfile.Visibility = Visibility.Collapsed;
                //  btnMyOrder.Visibility = Visibility.Collapsed;

            }
        }
        private void LoadOrderByCustomer()
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                Customer customer = context.Customers.FirstOrDefault(c => c.Email == currentUserEmail);

                if (customer != null)
                {
                    int customerID = customer.CustomerId;

                    List<ProjectPRN212.Models.Order> orders = context.Orders
                        .Where(o => o.CustomerId == customerID)
                        .ToList();

                    MyOrdersListView.ItemsSource = orders;
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
        }


        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int orderId)
            {
                Order.OrderDetail orderDetailsWindow = new Order.OrderDetail(orderId);
                orderDetailsWindow.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            PresentProduct presentProduct = new PresentProduct();
            presentProduct.ShowDialog();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            Cart.Cart cartWindow = new Cart.Cart();
            cartWindow.ShowDialog();
            this.Close();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Login_Register.Profile Profile = new Login_Register.Profile();
            Profile.ShowDialog();

            this.Close();

        }
        private void Received_Click(object sender, RoutedEventArgs e)
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                if (sender is Button button && button.Tag is int orderId)
                {
                    Models.Order order = context.Orders.FirstOrDefault(s => s.OrderId == orderId);
                    if (order != null)
                    {
                        order.OrderStatus = "Received";
                        context.Orders.Update(order);
                        context.SaveChanges();
                        LoadOrderByCustomer();
                    }

                }
            }

        }

        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                if (sender is Button button && button.Tag is int orderId)
                {
                    Models.Order order = context.Orders.FirstOrDefault(s => s.OrderId == orderId);
                    if (order != null)
                    {
                        var orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
                        foreach (var orderDetail in orderDetails)
                        {
                            var product = context.Products.FirstOrDefault(p => p.ProductId == orderDetail.ProductId);
                            if (product != null)
                            {
                                product.Quantity += orderDetail.Quantity;
                                context.Products.Update(product);
                                context.SaveChanges();
                            }
                        }

                        order.OrderStatus = "Cancelled";
                        context.Orders.Update(order);
                        context.SaveChanges();
                        LoadOrderByCustomer();
                    }
                }
            }
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

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            Login loginControl = new Login();
            loginControl.ShowDialog();
            this.Close();
        }
    }
}
