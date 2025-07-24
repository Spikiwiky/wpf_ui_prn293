using ProjectPRN212.CartModels;
using ProjectPRN212.GUI.Login_Register;
using ProjectPRN212.GUI.Order;
using ProjectPRN212.Login_Register;
using ProjectPRN212.Models;
using ProjectPRN212.Presentproduct;
using System.Windows;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Cart
{

    public partial class Cart : Window
    {
        string currentUserEmail = ApplicationState.CurrentUserSessionEmail;
        private List<CartItems> cartItems;
        public Cart()
        {
            InitializeComponent();
            CheckUserbtn();

            // Lấy giỏ hàng từ session state nếu đã lưu trước đó
            cartItems = Application.Current.Properties["CartItems"] as List<CartItems>;
            if (cartItems == null)
            {
                cartItems = new List<CartItems>();
            }

            UpdateCartListView();
            UpdateTotalAmount();
        }

        private void CheckUserbtn()
        {
            if (ApplicationState.customerSession != null)
            {
                btnProfile.Visibility = Visibility.Visible;
                btnMyOrder.Visibility = Visibility.Visible;
                btnLogout.Visibility = Visibility.Visible;
                btn_Login.Visibility = Visibility.Collapsed;

            }
            else
            {
                btnLogout.Visibility = Visibility.Collapsed;
                btn_Login.Visibility = Visibility.Visible;
                btnProfile.Visibility = Visibility.Collapsed;
                btnMyOrder.Visibility = Visibility.Collapsed;

            }
        }

        private void UpdateTotalAmount()
        {
            double totalAmount = cartItems.Sum(item => item.TotalPrice ?? 0);
            TotalAmountTextBlock.Text = totalAmount.ToString("C2");
        }

        private void UpdateCartListView()
        {
            CartItemsListView.ItemsSource = cartItems.ToList();

        }
        private void btnOrderNow_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ShopNewContext())
            {
                Customer customer = context.Customers.FirstOrDefault(c => c.Email == currentUserEmail);
                if (customer != null)
                {
                    double totalCost = cartItems.Sum(item => item.TotalPrice ?? 0);
                    this.Visibility = Visibility.Collapsed;
                    InforOrder InforOrder = new InforOrder(totalCost, cartItems);
                    InforOrder.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show(" Bạn cần login trước khi order !");
                    this.Visibility = Visibility.Collapsed;
                    Login loginControl = new Login();
                    loginControl.ShowDialog();
                    this.Close();
                }
            }

        }

        private void ButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            PresentProduct presentProduct = new PresentProduct();
            presentProduct.ShowDialog();
            this.Close();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            Profile profileWindow = new Profile();
            profileWindow.ShowDialog();
            this.Close();

        }

        private void btnMyOrder_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            MyOrder MyOrder = new MyOrder();
            MyOrder.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            ApplicationState.customerSession = null;
            CheckUserbtn();
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            Login loginControl = new Login();
            loginControl.ShowDialog();
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CartItems choosedItem = CartItemsListView.SelectedItem as CartItems;
            if (choosedItem != null)
            {
                // Tăng số lượng của mặt hàng được chọn lên 1 đơn vị
                choosedItem.Quantity++;

                // Cập nhật lại dữ liệu của choosedItem vào cartItems
                var itemUpdate = cartItems.FirstOrDefault(item => item.ProductID == choosedItem.ProductID);
                if (itemUpdate != null)
                {
                    itemUpdate.Quantity = choosedItem.Quantity;
                }
                UpdateCartListView();
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để thêm vào giỏ hàng.");
            }
        }


        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            CartItems choosedItem = CartItemsListView.SelectedItem as CartItems;
            if (choosedItem != null)
            {
                // Giảm số lượng của mặt hàng được chọn lên 1 đơn vị
                choosedItem.Quantity--;
                if(choosedItem.Quantity <= 0)
                {
                    removeCartItem(cartItems.FirstOrDefault(item => item.ProductID == choosedItem.ProductID));
                }

                // Cập nhật lại dữ liệu của choosedItem vào cartItems
                var itemUpdate = cartItems.FirstOrDefault(item => item.ProductID == choosedItem.ProductID);
                if (itemUpdate != null)
                {
                    itemUpdate.Quantity = choosedItem.Quantity;
                }
                UpdateCartListView();
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để thêm vào giỏ hàng.");
            }
        }

        private void btndelete_click(object sender, RoutedEventArgs e)
        {
            CartItems choosedItem = CartItemsListView.SelectedItem as CartItems;
            if (choosedItem != null)
            {
                var itemUpdate = cartItems.FirstOrDefault(item => item.ProductID == choosedItem.ProductID);
                removeCartItem(itemUpdate);
                UpdateCartListView();
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để thêm vào giỏ hàng.");
            }
        }
        private void removeCartItem(CartItems cartItem)
        {
            this.cartItems.Remove(cartItem);
        }
    }

}
