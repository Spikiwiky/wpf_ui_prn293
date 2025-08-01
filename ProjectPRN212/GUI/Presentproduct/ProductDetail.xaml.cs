﻿using Microsoft.Extensions.DependencyInjection;
using ProjectPRN212.CartModels;
using ProjectPRN212.Login_Register;
using ProjectPRN212.Models;
using ProjectPRN212.Presentproduct;
using ProjectPRN212.Service;
using System.Linq;
using System.Windows;

namespace ProjectPRN212.GUI.Presentproduct
{
    public partial class ProductDetail : Window
    {
        private readonly ProductApiService _productApiService;
        private int idProduct;
        private List<CartItems> cartItems = new List<CartItems>();
        public ProductDetail(int idProduct)
        {
            InitializeComponent();
            this.idProduct = idProduct;
            _productApiService = App.ServiceProvider.GetService<ProductApiService>();
            cartItems = Application.Current.Properties["CartItems"] as List<CartItems>;
            if (cartItems == null)
            {
                cartItems = new List<CartItems>();
            }
            LoadProductDetail();
        }

        //private void LoadProductDetail()
        //{
        //    using (var context = new ShopNewContext())
        //    {
        //        Product product = context.Products.FirstOrDefault(p => p.ProductId == idProduct);

        //        if (product != null)
        //        {
        //            this.DataContext = product;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Product not found!");
        //            this.Close();
        //        }
        //    }
        //}

        private async void LoadProductDetail()
        {
            var product = await _productApiService.GetProductByIdAsync(idProduct);

            if (product != null)
            {
                // Map sang ViewModel ẩn danh để binding
                this.DataContext = new
                {
                    ProductName = product.Name,
                    Summary = product.Description,
                    SalePrice = product.BasePrice,
                    ProductDetail = product.Brand,
                    Quantity = product.Variants?
                                      .SelectMany(v => v.Variants)
                                      .Sum(v => v.Stock) ?? 0,
                    Thumbnail = product.Images?.FirstOrDefault() ?? ""
                };
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm.");
                this.Close();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            PresentProduct PresentProduct = new PresentProduct();
            PresentProduct.ShowDialog();
            this.Close();
        }

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ShopNewContext())
            {

                Product selectedProduct = context.Products.FirstOrDefault(p => p.ProductId == idProduct);
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
    }
}
