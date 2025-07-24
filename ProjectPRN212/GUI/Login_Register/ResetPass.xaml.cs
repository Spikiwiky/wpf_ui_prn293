using ProjectPRN212.Login_Register;
using ProjectPRN212.Models;
using ProjectPRN212.SendMail;
using System.Windows;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Login_Register
{
    /// <summary>
    /// Interaction logic for ResetPass.xaml
    /// </summary>
    public partial class ResetPass : Window
    {
        string currentUserEmail = ApplicationState.CurrentUserSessionEmail;
        public ResetPass()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Login loginControl = new Login();
            loginControl.ShowDialog();
            this.Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmailReset.Text;

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            string randomPassword = GenerateRandomPassword();

            using (var context = new ShopNewContext())
            {
                Customer customer = context.Customers.FirstOrDefault(c => c.Email == email);

                if (customer != null)
                {
                    customer.Password = randomPassword;
                    context.Customers.Update(customer);
                    context.SaveChanges();


                    EmailService.SendEmailPassNew(email, "Reset Your Password", "Instructions to reset your password.", randomPassword);

                    MessageBox.Show($"Reset password instructions sent to {email}");

                    this.Visibility = Visibility.Collapsed;
                    Login loginControl = new Login();
                    loginControl.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật mật khẩu.");

                    this.Visibility = Visibility.Collapsed;
                    Login loginControl = new Login();
                    loginControl.ShowDialog();
                    this.Close();
                }
            }

            this.Close();
        }

        private string GenerateRandomPassword()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
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

    }
}
