using Microsoft.Extensions.DependencyInjection;
using ProjectPRN212.Models;
using ProjectPRN212.Service;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ProjectPRN212.Login_Register
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
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

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    string fullname = txtFullName.Text;
        //    string selectedGender = (string)((ComboBoxItem)Gender.SelectedItem).Tag;
        //    string phoneNumber = txtPhoneNumber.Text;
        //    string email = txtEmail.Text;
        //    string pass = txtPassword.Password;
        //    string re_pass = txtRePassword.Password;
        //    string address = txtAddress.Text;
        //    if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(selectedGender) || string.IsNullOrEmpty(phoneNumber) ||
        //        string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(re_pass) || string.IsNullOrEmpty(address))
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
        //        return;
        //    }
        //    else if (!IsValidEmail(email))
        //    {
        //        MessageBox.Show("Địa chỉ email không hợp lệ.");
        //        return;
        //    }
        //    else if (pass != re_pass)
        //    {
        //        MessageBox.Show("Nhập password phải giống nhau ");
        //        return;
        //    }
        //    else
        //    {

        //        using (ShopNewContext context = new ShopNewContext())
        //        {
        //            if (context.Customers.Any(c => c.Email == email))
        //            {
        //                MessageBox.Show("Địa chỉ email đã tồn tại . Vui lòng chọn một địa chỉ email khác.");
        //                return;
        //            }
        //            Customer newCustomer = new Customer
        //            {
        //                Fullname = fullname,
        //                Gender = selectedGender,
        //                PhoneNumber = phoneNumber,
        //                Email = email,
        //                Password = pass,
        //                Address = address,
        //                Status = true
        //            };
        //            context.Customers.Add(newCustomer);
        //            context.SaveChanges();
        //            MessageBox.Show("Tạo tài khoản thành công!");
        //            this.Visibility = Visibility.Collapsed;
        //            Login Login = new Login();
        //            Login.ShowDialog();
        //            this.Close();

        //        }
        //    }
        //}

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string fullname = txtFullName.Text.Trim();
            string selectedGender = (string)((ComboBoxItem)Gender.SelectedItem)?.Tag;
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Password;
            string re_pass = txtRePassword.Password;
            string address = txtAddress.Text.Trim();
            DateTime? dob = dpDateOfBirth.SelectedDate;

            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(selectedGender) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(re_pass) ||
                string.IsNullOrEmpty(address) || dob == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.");
                return;
            }

            if (pass != re_pass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.");
                return;
            }

            try
            {
                var authService = App.ServiceProvider.GetRequiredService<AuthApiService>();

                var registerDto = new RegisterRequestDto
                {
                    Email = email,
                    Password = pass,
                    UserName = fullname,
                    Phone = phoneNumber,
                    DateOfBirth = dob.Value,
                    Address = address
                };

                var result = await authService.RegisterAsync(registerDto);

                if (result == null || result.Message != "successful")
                {
                    MessageBox.Show(result?.Message ?? "Đăng ký thất bại. Vui lòng thử lại.");
                    return;
                }

                MessageBox.Show("Đăng ký thành công!");
                this.Close();
                new Login().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
