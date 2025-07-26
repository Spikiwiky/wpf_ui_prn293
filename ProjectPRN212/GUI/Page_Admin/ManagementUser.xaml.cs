using ProjectPRN212.Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class ManagementUser : Window
    {
        private readonly UserApiService _userService;

        public ObservableCollection<UserDto> Users { get; set; } = new ObservableCollection<UserDto>();

        public ManagementUser(UserApiService userService)
        {
            InitializeComponent();
            _userService = userService;

            DataContext = this;
            LoadUsersAsync();
        }

        private async void LoadUsersAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                Users.Clear();
                foreach (var user in users)
                {
                    Users.Add(user);
                }

                dgUsers.ItemsSource = Users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load users: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void lockUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem is UserDto selectedUser)
            {
                selectedUser.Status = 0;
                var success = await _userService.UpdateUserAsync(selectedUser); // ✅ changed here

                if (success)
                {
                    MessageBox.Show("User locked successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show("Failed to lock user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void UnlockUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem is UserDto selectedUser)
            {
                selectedUser.Status = 1;
                var success = await _userService.UpdateUserAsync(selectedUser); // ✅ changed here

                if (success)
                {
                    MessageBox.Show("User unlocked successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show("Failed to unlock user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            ApplicationState.RoleName = null;
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            // Open admin profile window
        }

        private void btnManageProduct_Click(object sender, RoutedEventArgs e)
        {
            //var productWindow = new ProductManagementWindow();
            //productWindow.Show();
            //this.Close();
        }
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUser(_userService);
            bool? result = addUserWindow.ShowDialog();
            if (result == true && addUserWindow.NewUser != null)
            {
                Users.Add(addUserWindow.NewUser);
            }
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (sender as FrameworkElement)?.DataContext as UserDto;
            if (selectedUser == null) return;

            var editWindow = new EditUser(selectedUser, _userService, ApplicationState.RoleName == "Admin");
            bool? result = editWindow.ShowDialog();

            if (result == true)
            {
                // Optionally reload the specific user if needed
                var updatedUser = await _userService.GetUserByIdAsync(selectedUser.UserId);

                // Update the fields manually
                selectedUser.UserName = updatedUser.UserName;
                selectedUser.Phone = updatedUser.Phone;
                selectedUser.Email = updatedUser.Email;
                selectedUser.Address = updatedUser.Address;
                selectedUser.Status = updatedUser.Status;
                selectedUser.RoleId = updatedUser.RoleId;

                // Force refresh the DataGrid
                dgUsers.Items.Refresh();
            }
        }



    }
}
