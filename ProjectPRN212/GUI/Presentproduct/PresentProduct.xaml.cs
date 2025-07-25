using Microsoft.Extensions.DependencyInjection;
using ProjectPRN212.CartModels;
using ProjectPRN212.GUI.Cart;
using ProjectPRN212.GUI.Login_Register;
using ProjectPRN212.GUI.Order;
using ProjectPRN212.GUI.Presentproduct;
using ProjectPRN212.Login_Register;
using ProjectPRN212.Models;
using ProjectPRN212.Service;
using System.Windows;
using static ProjectPRN212.Login_Register.Login;
namespace ProjectPRN212.Presentproduct
{

    public partial class PresentProduct : Window
    {
        public List<CartItems> cartItems = new List<CartItems>();
        private readonly ProductApiService _productApiService;

        public PresentProduct()
        {
            InitializeComponent();
            _productApiService = App.ServiceProvider.GetService<ProductApiService>();
            CheckUserbtn();
            LoadCategories();
            LoadProducts();
            cartItems = Application.Current.Properties["CartItems"] as List<CartItems>;
            if (cartItems == null)
            {
                cartItems = new List<CartItems>();
            }

        }
        private void CheckUserbtn()
        {
            if (ApplicationState.RoleName != null)
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

        //private void LoadProducts()
        //{
        //    using (ShopNewContext context = new ShopNewContext())
        //    {


        //        List<Product> products = context.Products.Where(e => e.ProductStatus == true).Where(e => e.IsDeleted == false).ToList();

        //        ProductListBox.ItemsSource = products;
        //    }
        //}

        private async void LoadProducts()
        {
            var products = await _productApiService.GetPagedProductsAsync(1, 10);
            if (products != null)
            {
                ProductListBox.ItemsSource = products.Select(p => new
                {
                    ProductId = p.ProductId,
                    ProductName = p.Name,
                    SalePrice = p.BasePrice,
                    Thumbnail = p.Images?.FirstOrDefault() ?? ""
                }).ToList();
            }
            else
            {
                MessageBox.Show("Không thể tải danh sách sản phẩm.");
            }
        }



        //private void btnSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    string nameProduct = txtSearch.Text.ToLower();
        //    using (ShopNewContext context = new ShopNewContext())
        //    {
        //        var filteredProducts = context.Products
        //                                      .Where(p => p.ProductName.ToLower().Contains(nameProduct))
        //                                      .Where(p => p.ProductStatus == true)
        //                                      .Where(e => e.IsDeleted == false)
        //                                      .ToList();
        //        ProductListBox.ItemsSource = filteredProducts;
        //    }
        //}


        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string nameProduct = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(nameProduct))
            {
                LoadProducts(); // Nếu để trống, gọi lại toàn bộ
                return;
            }

            var results = await _productApiService.SearchProductsByNameAsync(nameProduct, 1, 10);
            if (results != null && results.Any())
            {
                ProductListBox.ItemsSource = results.Select(p => new
                {
                    ProductId = p.ProductId,
                    ProductName = p.Name,
                    SalePrice = p.BasePrice,
                    Thumbnail = p.Images?.FirstOrDefault() ?? ""
                }).ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm.");
            }
        }

        private void LoadCategories()
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                var categories = context.ProductCategories
                                         .Select(e => new
                                         {
                                             CategoryId = e.CategoryId,
                                             CategoryName = e.CategoryName
                                         }).Distinct();
                cbCategory.ItemsSource = categories.ToList();
                cbCategory.DisplayMemberPath = "CategoryName";
                cbCategory.SelectedValuePath = "CategoryId";

                cbCategory.SelectedIndex = 0;
            }
        }



        //private void Detail_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ProductListBox.Items.Count == 0)
        //    {
        //        MessageBox.Show("Không có sản phẩm nào để show .");
        //        return;
        //    }
        //    if (ProductListBox.SelectedItem != null)
        //    {
        //        Product selectedProduct = (Product)ProductListBox.SelectedItem;
        //        this.Visibility = Visibility.Collapsed;
        //        int idProduct = selectedProduct.ProductId;
        //        ProductDetail productDetail = new ProductDetail(idProduct);
        //        productDetail.ShowDialog();
        //        this.Close();
        //    }

        //}

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListBox.Items.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để show.");
                return;
            }

            if (ProductListBox.SelectedItem != null)
            {
                dynamic selectedItem = ProductListBox.SelectedItem;
                int idProduct = selectedItem.ProductId;
                this.Visibility = Visibility.Collapsed;
                ProductDetail productDetail = new ProductDetail(idProduct);
                productDetail.ShowDialog();
                this.Close();
            }
        }

        private void cbCategory_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbCategory.SelectedValue != null)
            {
                int selectedCategoryId = (int)cbCategory.SelectedValue;
                using (ShopNewContext context = new ShopNewContext())
                {
                    if (selectedCategoryId == 9)
                    {
                        LoadProducts();
                    }
                    else
                    {
                        var filteredProducts = context.Products
                                                      .Where(p => p.CategoryId == selectedCategoryId).Where(e => e.ProductStatus == true).Where(e => e.IsDeleted == false)
                                                      .ToList();
                        ProductListBox.ItemsSource = filteredProducts;
                    }
                }
            }

        }
        private void btnBuy_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            if (ProductListBox.Items.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để mua.");
                return;
            }

            if (ProductListBox.SelectedItem != null)
            {
                using (var context = new ShopNewContext())
                {

                    Product selectedProduct = (Product)ProductListBox.SelectedItem;
                    var productInDb = context.Products.FirstOrDefault(p => p.ProductId == selectedProduct.ProductId);
                    // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
                    CartItems existingItem = cartItems.FirstOrDefault(item => item.ProductID == selectedProduct.ProductId);
                    if (existingItem != null)
                    {

                        if (existingItem.Quantity + 1 > productInDb.Quantity)
                        {
                            MessageBox.Show($"Sản phẩm {selectedProduct.ProductName} đã hết hàng.");
                            return;
                        }

                        else
                        {
                            existingItem.Quantity++;
                            MessageBox.Show($"Bạn đã mua {existingItem.Quantity} {selectedProduct.ProductName}");
                        }
                    }
                    else
                    {
                        if (1 > productInDb.Quantity)
                        {
                            MessageBox.Show($"Sản phẩm {selectedProduct.ProductName} đã hết hàng.");
                            return;
                        }
                        else
                        {
                            MessageBox.Show($"Bạn đã mua sản phẩm {selectedProduct.ProductName}");
                            CartItems newItem = new CartItems
                            {
                                ProductID = selectedProduct.ProductId,
                                ProductName = selectedProduct.ProductName,
                                SalePrice = selectedProduct.SalePrice,
                                Quantity = 1,
                                Thumbnail = selectedProduct.Thumbnail,
                                // TotalPrice = selectedProduct.SalePrice
                            };
                            cartItems.Add(newItem);
                            // Lưu lại danh sách giỏ hàng vào session state
                            Application.Current.Properties["CartItems"] = cartItems;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trước khi mua.");
            }
        }



        private void btnCart_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            Cart cartWindow = new Cart();
            cartWindow.ShowDialog();
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {


            this.Visibility = Visibility.Collapsed;
            Profile profileDialog = new Profile();
            profileDialog.ShowDialog();
            this.Close();

        }

        private void btnMyOrder_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            MyOrder MyOrders = new MyOrder();
            MyOrders.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

            //ApplicationState.customerSession = null;
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
    }



}
