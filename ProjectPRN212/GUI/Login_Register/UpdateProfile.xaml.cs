using ProjectPRN212.Models;
using System.Windows;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Login_Register
{
    /// <summary>
    /// Interaction logic for UpdateProfile.xaml
    /// </summary>
    public partial class UpdateProfile : Window
    {
        string currentUserEmail = ApplicationState.CurrentUserSessionEmail;
        public UpdateProfile()

        {
            InitializeComponent();
            loadInfomation();

        }

        private void loadInfomation()
        {
            using (var context = new ShopNewContext())
            {
                Customer customer = context.Customers
                    .FirstOrDefault(c => c.Email == currentUserEmail);
                staff staff = context.staff
                   .FirstOrDefault(c => c.Email == currentUserEmail);
                if (customer != null)
                {
                    txtFullName.Text = customer.Fullname;
                    txtGender.Text = customer.Gender;
                    txtPhoneNumber.Text = customer.PhoneNumber;
                    txtAddress.Text = customer.Address;
                }
                if (staff != null)
                {
                    txtFullName.Text = staff.Fullname;
                    txtGender.Text = staff.Gender;
                    txtPhoneNumber.Text = staff.PhoneNumber;
                    txtAddress.Text = staff.Address;
                }
            }
        }

        private void updateInformation()
        {

            using (var context = new ShopNewContext())
            {
                Customer customerToUpdate = context.Customers
                    .FirstOrDefault(c => c.Email == currentUserEmail);
                staff staffToUpdate = context.staff
                 .FirstOrDefault(c => c.Email == currentUserEmail);
                if (customerToUpdate != null)
                {
                    Customer entity = context.Customers.Find(customerToUpdate.CustomerId) as Customer;
                    if (entity != null)
                    {
                        entity.Fullname = txtFullName.Text;
                        entity.PhoneNumber = txtPhoneNumber.Text;
                        entity.Gender = txtGender.Text;
                        entity.Address = txtAddress.Text;
                        entity.UpdateDate = DateTime.Now;
                        context.Customers.Update(entity);
                        context.SaveChanges();

                    }
                }
                if (staffToUpdate != null)
                {
                    staff entity = context.staff.Find(staffToUpdate.StaffId) as staff;
                    if (entity != null)
                    {
                        entity.Fullname = txtFullName.Text;
                        entity.PhoneNumber = txtPhoneNumber.Text;
                        entity.Gender = txtGender.Text;
                        entity.Address = txtAddress.Text;
                        entity.UpdateDate = DateTime.Now;
                        context.staff.Update(entity);
                        context.SaveChanges();

                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateInformation();
            this.Visibility = Visibility.Collapsed;
            Profile Profile = new Profile();
            Profile.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Profile Profile = new Profile();
            Profile.ShowDialog();
            this.Close();
        }
    }
}
