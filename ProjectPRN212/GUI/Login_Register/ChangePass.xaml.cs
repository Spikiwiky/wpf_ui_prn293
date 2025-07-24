using ProjectPRN212.Models;
using System.Windows;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Login_Register
{
    /// <summary>
    /// Interaction logic for ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Window
    {
        string currentUserEmail = ApplicationState.CurrentUserSessionEmail;
        public ChangePass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ShopNewContext())
            {
                Customer customer = context.Customers
                  .FirstOrDefault(c => c.Email == currentUserEmail);
                Customer entityCustomer = context.Customers.Find(customer.CustomerId) as Customer;

                if (string.IsNullOrEmpty(txtCurrentPassword.Password) || string.IsNullOrEmpty(txtNewPassword.Password) || string.IsNullOrEmpty(txtConfirmPassword.Password))
                {
                    MessageBox.Show("Các trường thông tin không được để trống  ! ");
                    return;
                }
                else if (entityCustomer.Password != txtCurrentPassword.Password)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng ! ");
                    return;
                }

                else if (txtNewPassword.Password != txtConfirmPassword.Password)
                {
                    MessageBox.Show("Mật khẩu mới phải giống nhau  ! ");
                    return;
                }
                else
                {


                    entityCustomer.Password = txtNewPassword.Password;
                    context.Customers.Update(entityCustomer);
                    context.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công  ! ");
                    this.Visibility = Visibility.Collapsed;
                    Profile Profile = new Profile();
                    Profile.ShowDialog();
                    this.Close();




                }

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Profile Profile = new Profile();
            Profile.ShowDialog();

            this.Close();
        }
    }
}
