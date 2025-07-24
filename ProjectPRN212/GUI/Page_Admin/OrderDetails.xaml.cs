using ProjectPRN212.Models;
using System.Windows;

namespace ProjectPRN212.GUI.Page_Admin
{

    public partial class OrderDetails : Window
    {
        int orderID;
        public OrderDetails(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
            LoadOrderDetails();


        }

        private void LoadOrderDetails()
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                var order = context.Orders.FirstOrDefault(es => es.OrderId == orderID);
                if (order == null)
                {
                    MessageBox.Show("Order not found.");
                    return;
                }
                Customer customer = context.Customers.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                string emailCustomer = customer?.Email;
                string orderDateString = order.OrderDate.HasValue ? order.OrderDate.Value.ToString("MM/dd/yyyy") : "N/A";
                txtOrderDate.Text = orderDateString;
                txtReceiver_fullname.Text = order.ReceiverFullname ?? "N/A";
                txtReceiver_email.Text = order.ReceiverEmail ?? "N/A";
                txtPhone_number.Text = order.PhoneNumber ?? "N/A";
                txtReceiver_address.Text = order.ReceiverAddress ?? "N/A";
                txtNote.Text = order.Note ?? "N/A";
                txtEmailOfCustomer.Text = emailCustomer;
                var orderDetails = context.OrderDetails
                               .Where(od => od.OrderId == orderID)
                               .Select(od => new
                               {
                                   ProductName = od.Product.ProductName,
                                   Quantity = od.Quantity,
                                   ProductPrice = od.ProductPrice,
                                   TotalPrice = od.Quantity * od.ProductPrice
                               })
                               .ToList();
                decimal totalOrderAmount = orderDetails.Sum(od => (decimal)(od.TotalPrice ?? 0.0));
                txtTotalOrder.Text = totalOrderAmount.ToString();
                lvOrderDetails.ItemsSource = orderDetails;

            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
