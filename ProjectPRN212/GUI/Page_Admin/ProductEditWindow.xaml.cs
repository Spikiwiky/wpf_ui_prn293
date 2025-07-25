using ProjectPRN212.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using static ProjectPRN212.Service.AdminProductApiService;

namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class ProductEditWindow : Window
    {
        private readonly AdminProductApiService _productService;
        private ProductDTO _product;
        private string? _selectedImagePath;
        private readonly string _apiBaseUrl = "https://localhost:7257"; // or your deployed API base

        private readonly Dictionary<int, string> _categories = new()
        {
            { 1, "Men Clothing" },
            { 2, "Women Clothing" },
            { 3, "Kids Clothing" },
            { 4, "Sportswear" },
            { 5, "Accessories" },
            { 6, "Footwear" },
            { 7, "Outerwear" },
            { 8, "Underwear" },
            { 9, "Swimwear" },
            { 10, "Formal Wear" }
        };

        public ProductEditWindow(AdminProductApiService productService, ProductDTO product)
        {
            InitializeComponent();
            _productService = productService;
            _product = product;

            CategoryComboBox.ItemsSource = _categories;
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            NameTextBox.Text = _product.Name;
            BrandTextBox.Text = _product.Brand;
            BasePriceTextBox.Text = _product.BasePrice.ToString("0.##");
            DescriptionTextBox.Text = _product.Description;
            CategoryComboBox.SelectedValue = _product.CategoryId;

            var url = _product.GetFirstImageUrl(_apiBaseUrl);
            var imageUrl = "https://localhost:7257/" + url;


            if (!string.IsNullOrEmpty(imageUrl))
            {
                ProductImagePreview.Source = new BitmapImage(new Uri(url));
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _product.Name = NameTextBox.Text;
                _product.Brand = BrandTextBox.Text;
                _product.Description = DescriptionTextBox.Text;
                _product.BasePrice = decimal.TryParse(BasePriceTextBox.Text, out var price) ? price : 0;
                _product.CategoryId = (int)(CategoryComboBox.SelectedValue ?? 1);

                if (!string.IsNullOrEmpty(_selectedImagePath))
                {
                    var result = await _productService.UploadProductImageAsync(_product.ProductId, _selectedImagePath);
                    if (result == null)
                    {
                        System.Windows.MessageBox.Show("Image upload failed.");
                        return;
                    }

                    _product.Images.Clear();
                    _product.Images.Add(result); 
                }

                var success = await _productService.UpdateProductAsync(_product.ProductId, _product);
                if (success)
                {
                    System.Windows.MessageBox.Show("Product updated successfully.");
                    DialogResult = true;
                    Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to update product.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _selectedImagePath = dialog.FileName;
                ProductImagePreview.Source = new BitmapImage(new Uri(_selectedImagePath));
            }
        }
    }
}
