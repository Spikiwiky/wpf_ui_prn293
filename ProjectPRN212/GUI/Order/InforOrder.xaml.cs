using ProjectPRN212.CartModels;
using ProjectPRN212.Models;
using ProjectPRN212.Presentproduct;
using ProjectPRN212.SendMail;
using System.Windows;
using System.Windows.Controls;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Order
{
    public partial class InforOrder : Window
    {
        private double totalCost;
        private List<CartItems> cartItems;
        string currentUserEmail = ApplicationState.CurrentUserSessionEmail;
        public InforOrder(double totalCost, List<CartItems> cartItems)
        {
            InitializeComponent();
            this.totalCost = totalCost;
            this.cartItems = cartItems;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtReceiverFullName.Text) ||
                 cbxGender.SelectedItem == null ||
                 string.IsNullOrEmpty(txtReceiverEmail.Text) ||
                 string.IsNullOrEmpty(txtPhoneNumber.Text) ||
                 string.IsNullOrEmpty(txtReceiverAddress.Text) ||
                 string.IsNullOrEmpty(txtNote.Text))
            {
                MessageBox.Show("Thông tin không được để trống ");
                return;
            }
            else if (!IsValidEmail(txtReceiverEmail.Text))
            {
                MessageBox.Show("Nhập đúng định dạng email !");
                return;
            }
            else
            {
                using (var context = new ShopNewContext())
                {
                    Customer customer = context.Customers
                     .FirstOrDefault(c => c.Email == currentUserEmail);
                    string receiverFullName = txtReceiverFullName.Text;
                    string receiverGender = (cbxGender.SelectedItem as ComboBoxItem)?.Content.ToString();
                    string receiverEmail = txtReceiverEmail.Text;
                    string phoneNumber = txtPhoneNumber.Text;
                    string receiverAddress = txtReceiverAddress.Text;
                    string note = txtNote.Text;
                    Models.Order newOrder = new Models.Order
                    {
                        CustomerId = customer.CustomerId,
                        StaffId = 19,
                        ReceiverFullname = receiverFullName,
                        ReceiverGender = receiverGender,
                        ReceiverEmail = receiverEmail,
                        PhoneNumber = phoneNumber,
                        ReceiverAddress = receiverAddress,
                        OrderDate = DateTime.Now,
                        TotalCost = totalCost,
                        Note = note,
                        OrderStatus = "Ordered",
                        IsDeleted = false
                    };
                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                    foreach (var item in cartItems)
                    {
                        var product = context.Products.FirstOrDefault(p => p.ProductId == item.ProductID);
                        if (product != null && product.Quantity >= item.Quantity)
                        {
                            product.Quantity -= item.Quantity;
                            Models.OrderDetail orderDetail = new Models.OrderDetail
                            {
                                OrderId = newOrder.OrderId,
                                ProductId = item.ProductID,
                                Quantity = item.Quantity,
                                ProductPrice = item.SalePrice,
                                TotalCost = item.Quantity * item.SalePrice,
                            };
                            context.OrderDetails.Add(orderDetail);
                        }
                        else
                        {
                            MessageBox.Show($"Sản phẩm {item.ProductName} không đủ số lượng trong kho.");
                            return;
                        }

                    }

                    context.SaveChanges();


                    newOrder.TotalCost = cartItems.Sum(i => i.TotalPrice ?? 0);
                    context.SaveChanges();
                    MessageBox.Show("Order placed successfully.");

                    EmailService.SendEmailWithOrderDetails(currentUserEmail, newOrder, cartItems);

                    MessageBox.Show("Order placed successfully and email sent.");
                    ClearFields();
                    cartItems.Clear();
                    Application.Current.Properties["CartItems"] = null;
                    this.Visibility = Visibility.Collapsed;
                    PresentProduct presentProduct = new PresentProduct();
                    presentProduct.ShowDialog();

                    this.Close();


                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ClearFields()
        {
            txtReceiverFullName.Text = string.Empty;
            cbxGender.SelectedItem = null;
            txtReceiverEmail.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtReceiverAddress.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            PresentProduct PresentProduct = new PresentProduct();
            PresentProduct.ShowDialog();
            this.Close();
        }
    }
}
