using ProjectPRN212.GUI.Page_Admin;
using ProjectPRN212.Models;
using System.Windows;
using System.Windows.Media.Imaging;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Login_Register
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            LoadInformation();
        }

        private void LoadInformation()
        {
            string currentUserEmail = ApplicationState.CurrentUserSessionEmail;

            using (var context = new ShopNewContext())
            {
                Customer customer = context.Customers
                    .FirstOrDefault(c => c.Email == currentUserEmail);

                staff staffs = context.staff
                    .FirstOrDefault(c => c.Email == currentUserEmail);

                if (customer != null)
                {
                    btnChangePassword.Visibility = Visibility.Visible;
                    txtFullName.Text = customer.Fullname;
                    txtGender.Text = customer.Gender;
                    txtPhoneNumber.Text = customer.PhoneNumber;
                    txtEmail.Text = customer.Email;
                    txtAddress.Text = customer.Address;
                    if (!string.IsNullOrEmpty(customer.Avatar))
                    {
                        imgAvatar.Source = new BitmapImage(new Uri(customer.Avatar));
                    }
                    else
                    {
                        Uri uri = new Uri("https://png.pngtree.com/png-vector/20190623/ourlarge/pngtree-accountavataruser--flat-color-icon--vector-icon-banner-templ-png-image_1491720.jpg");
                        BitmapImage bitmapImage = new BitmapImage(uri);
                        imgAvatar.Source = bitmapImage;
                    }
                }
                if (staffs != null)
                {
                    btnChangePassword.Visibility = Visibility.Collapsed;
                    txtFullName.Text = staffs.Fullname;
                    txtGender.Text = staffs.Gender;
                    txtPhoneNumber.Text = staffs.PhoneNumber;
                    txtEmail.Text = staffs.Email;
                    txtAddress.Text = staffs.Address;
                    if (!string.IsNullOrEmpty(staffs.Avatar))
                    {
                        imgAvatar.Source = new BitmapImage(new Uri(staffs.Avatar));
                    }
                    else
                    {
                        Uri uri = new Uri("https://png.pngtree.com/png-vector/20190623/ourlarge/pngtree-accountavataruser--flat-color-icon--vector-icon-banner-templ-png-image_1491720.jpg");
                        BitmapImage bitmapImage = new BitmapImage(uri);
                        imgAvatar.Source = bitmapImage;
                    }
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            if (ApplicationState.RoleName == "Customer")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            }
            else if (ApplicationState.RoleName == "Admin")
            {
                MainPageAdmin MainPageAdmin = new MainPageAdmin();
                MainPageAdmin.ShowDialog();
            }
            else if (ApplicationState.RoleName == "Sale")
            {
                ManagementOrder ManagementOrder = new ManagementOrder();
                ManagementOrder.ShowDialog();
            }
        }






        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            UpdateProfile updateProfile = new UpdateProfile();
            updateProfile.ShowDialog();
            this.Close();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            ChangePass ChangePass = new ChangePass();
            ChangePass.ShowDialog();
            this.Close();

        }
    }
}
