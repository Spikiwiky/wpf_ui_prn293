using System;
using System.Windows;
using ProjectPRN212.Models;
using ProjectPRN212.Service;


namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class AddUser : Window
    {
        private readonly UserApiService _userService;

        public AddUser(UserApiService userService)
        {
            InitializeComponent();
            _userService = userService;
        }
        public UserDto NewUser { get; private set; }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new UserDto
            {
                UserName = txtUserName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Password,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                RoleId = int.TryParse(txtRoleId.Text, out var roleId) ? roleId : 3,
                Status = 1,
                CreateDate = DateTime.Now,
                DateOfBirth = dpDOB.SelectedDate ?? DateTime.Today
            };

            var result = await _userService.CreateUserAsync(newUser);
            if (result)
            {
                NewUser = newUser;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to add user.");
            }
        }
    }
}
