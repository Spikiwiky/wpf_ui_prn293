using Microsoft.Extensions.DependencyInjection;
using ProjectPRN212.GUI.Login_Register;
using ProjectPRN212.GUI.Page_Admin;
using ProjectPRN212.Models;
using ProjectPRN212.Service;
using System.Text.RegularExpressions;
using System.Windows;

namespace ProjectPRN212.Login_Register
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly AuthApiService _authApiService;
        public Login()
        {
            InitializeComponent();
            _authApiService = App.ServiceProvider.GetRequiredService<AuthApiService>();
        }
        //public static class ApplicationState
        //{
        //    public static string CurrentUserSessionEmail { get; set; }

        //    public static Customer customerSession { get; set; }
        //    public static staff staffSession { get; set; }

        //}

        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    string email = txtEmail.Text;
        //    string password = txtPassword.Password;
        //    ApplicationState.CurrentUserSessionEmail = email;
        //    using (ShopNewContext context = new ShopNewContext())
        //    {
        //        ApplicationState.customerSession = context.Customers.FirstOrDefault(c => c.Email == email && c.Password == password && c.Status == true);
        //        ApplicationState.staffSession = context.staff.FirstOrDefault(c => c.Email == email && c.Password == password && c.Status == true);

        //    }

        //    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        //    {
        //        MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
        //        ApplicationState.CurrentUserSessionEmail = null;
        //        ApplicationState.customerSession = null;
        //        ApplicationState.staffSession = null;
        //        return;
        //    }
        //    else if (!IsValidEmail(email))
        //    {
        //        MessageBox.Show("Tên đăng nhập phải là địa chỉ email hợp lệ.");
        //        ApplicationState.CurrentUserSessionEmail = null;
        //        ApplicationState.customerSession = null;
        //        ApplicationState.staffSession = null;
        //        return;
        //    }
        //    else if (IsValidAdmin(email, password))
        //    {
        //        MessageBox.Show("Đăng nhập Admin  thành công!");

        //        this.Visibility = Visibility.Collapsed;
        //        MainPageAdmin mainPageAdmin = new MainPageAdmin();
        //        mainPageAdmin.ShowDialog();
        //        ApplicationState.customerSession = null;
        //        this.Close();
        //    }
        //    else if (IsValidSale(email, password))
        //    {
        //        MessageBox.Show("Đăng nhập saler thành công!");

        //        this.Visibility = Visibility.Collapsed;
        //        ManagementOrder ManagementOrder = new ManagementOrder();
        //        ManagementOrder.ShowDialog();
        //        ApplicationState.customerSession = null;
        //        this.Close();
        //    }
        //    else if (IsValidUser(email, password))
        //    {
        //        MessageBox.Show("Đăng nhập thành công!");
        //        this.Visibility = Visibility.Collapsed;
        //        MainWindow mainWindow = new MainWindow();
        //        mainWindow.ShowDialog();
        //        ApplicationState.staffSession = null;
        //        this.Close();
        //    }
        //    else if (IsValidUserLock(email, password))
        //    {
        //        ApplicationState.CurrentUserSessionEmail = null;
        //        ApplicationState.customerSession = null;
        //        ApplicationState.staffSession = null;
        //        MessageBox.Show("Account đã bị khóa !");
        //        return;
        //    }
        //    else
        //    {
        //        ApplicationState.CurrentUserSessionEmail = null;
        //        ApplicationState.customerSession = null;
        //        ApplicationState.staffSession = null;
        //        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác. Vui lòng thử lại.");
        //        return;
        //    }
        //}

        //private bool IsValidUserLock(string email, string password)
        //{
        //    using (ShopNewContext context = new ShopNewContext())
        //    {
        //        Customer customer = context.Customers.FirstOrDefault(c => c.Email == email && c.Password == password && c.Status == false);
        //        return customer != null;
        //    }
        //}

        //private bool IsValidSale(string email, string password)
        //{
        //    try
        //    {
        //        using (ShopNewContext context = new ShopNewContext())
        //        {
        //            staff staffs = context.staff.FirstOrDefault(c => c.Email == email && c.Password == password && c.RoleId == 2 && c.Status == true);

        //            if (staffs != null)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Đã xảy ra lỗi khi kiểm tra dữ liệu admin: " + ex.Message);
        //        return false;
        //    }
        //}

        //private bool IsValidAdmin(string email, string password)
        //{
        //    try
        //    {
        //        using (ShopNewContext context = new ShopNewContext())
        //        {
        //            staff staffs = context.staff.FirstOrDefault(c => c.Email == email && c.Password == password && c.RoleId == 1 && c.Status == true);

        //            if (staffs != null)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Đã xảy ra lỗi khi kiểm tra dữ liệu admin: " + ex.Message);
        //        return false;
        //    }
        //}
        //private bool IsValidUser(string email, string password)
        //{
        //    using (ShopNewContext context = new ShopNewContext())
        //    {
        //        Customer customer = context.Customers.FirstOrDefault(c => c.Email == email && c.Password == password && c.Status == true);
        //        return customer != null;
        //    }

        //}


        public static class ApplicationState
        {
            public static string Token { get; set; }
            public static string RoleName { get; set; }
            public static string UserName { get; set; }
            public static int UserId { get; set; }
            public static string CurrentUserSessionEmail { get; set; }
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password.Trim();
            ApplicationState.CurrentUserSessionEmail = email;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Tên đăng nhập phải là địa chỉ email hợp lệ.");
                return;
            }

            var loginDto = new LoginRequestDto
            {
                Email = email,
                Password = password
            };

            try
            {
                var response = await _authApiService.LoginAsync(loginDto);

                if (response == null || response.message != "successful")
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin.");
                    return;
                }

                // Lưu thông tin người dùng vào ApplicationState
                ApplicationState.Token = response.token;
                ApplicationState.UserId = response.userId;
                ApplicationState.RoleName = response.roleName;
                ApplicationState.UserName = response.userName;

                MessageBox.Show($"Đăng nhập thành công! Xin chào {response.userName}");

                // Điều hướng theo vai trò
                this.Visibility = Visibility.Collapsed;

                if (response.roleName == "Admin")
                {
                    var userService = App.ServiceProvider.GetRequiredService<UserApiService>();
                    new MainPageAdmin(userService).ShowDialog();
                }
                else if (response.roleName == "Sale" || response.roleName == "Staff")
                {
                    new ManagementOrder().ShowDialog();
                }
                else
                {
                    new MainWindow().ShowDialog();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gọi API: " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Register registerControl = new Register();
            registerControl.ShowDialog();
            this.Close();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            ResetPass ResetPass = new ResetPass();
            ResetPass.Show();
            this.Close();
        }

    }
}
