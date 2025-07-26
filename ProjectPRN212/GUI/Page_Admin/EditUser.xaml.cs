
using ProjectPRN212.Service;

using System.Windows;

namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class EditUser : Window
    {
        private readonly UserApiService _userService;
        private readonly bool _isAdmin;
        private UserDto _user;

        public EditUser(UserDto user, UserApiService userService, bool isAdmin)
        {
            InitializeComponent();

            _user = user;
            _userService = userService;
            _isAdmin = isAdmin;

            // Disable role input if not admin
            RoleIdTextBox.IsEnabled = _isAdmin;

            this.DataContext = _user;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _userService.UpdateUserAsync(_user);
                MessageBox.Show("User updated successfully!");
                this.DialogResult = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
