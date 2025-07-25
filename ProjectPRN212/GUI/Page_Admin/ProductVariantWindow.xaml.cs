using ProjectPRN212.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows;
using static ProjectPRN212.Service.AdminProductApiService;

namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class ProductVariantWindow : Window
    {
        private readonly AdminProductApiService _apiService;
        public ProductDTO Product { get; set; }
        public ObservableCollection<VariantAttributeInput> VariantAttributes { get; set; } = new();

        public decimal NewPrice { get; set; }
        public int NewStock { get; set; }

        public ProductVariantWindow(AdminProductApiService apiService, ProductDTO product)
        {
            InitializeComponent();
            _apiService = apiService;
            Product = product;
            LoadAttributes();
            DataContext = this;
        }

        private void LoadAttributes()
        {
            VariantAttributes.Clear();

            if (!string.IsNullOrEmpty(Product.AvailableAttributes))
            {
                var attrDict = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(Product.AvailableAttributes);
                foreach (var attr in attrDict)
                {
                    VariantAttributes.Add(new VariantAttributeInput
                    {
                        AttributeName = attr.Key,
                        Values = new ObservableCollection<string>(attr.Value)
                    });
                }
            }
        }

        private async void OnAddVariantValueClick(object sender, RoutedEventArgs e)
        {
            var selectedAttrs = VariantAttributes
                .Where(a => a.IsSelected && !string.IsNullOrEmpty(a.SelectedValue))
                .ToDictionary(a => a.AttributeName, a => a.SelectedValue);

            if (selectedAttrs.Count == 0 || NewPrice <= 0 || NewStock <= 0)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            var newValue = new Dictionary<string, object>();

            // Copy selected attribute-value pairs
            foreach (var attr in selectedAttrs)
            {
                newValue[attr.Key] = attr.Value;
            }

            // Add price and stock
            newValue["price"] = NewPrice;
            newValue["stock"] = NewStock;

            if (Product.Variants.Any())
            {
                var firstVariant = Product.Variants[0];
                firstVariant.Variants ??= new List<Dictionary<string, object>>();
                firstVariant.Variants.Add(newValue);

                var result = await _apiService.UpdateProductVariantAsync(firstVariant);
                MessageBox.Show(result ? "Added variant value successfully." : "Failed to update variant.");
            }
            else
            {
                var newVariant = new AdminProductApiService.ProductVariantDTO
                {
                    ProductId = Product.ProductId,
                    Attributes = JsonSerializer.Serialize(selectedAttrs),
                    Variants = new List<Dictionary<string, object>> { newValue }
                };

                var result = await _apiService.AddProductVariantAsync(newVariant);
                MessageBox.Show(result ? "Created new variant successfully." : "Failed to add variant.");
            }

            // Optionally: Reset input fields
            NewPrice = 0;
            NewStock = 0;
            foreach (var attr in VariantAttributes)
                attr.SelectedValue = null;
        }

    }

    public class VariantAttributeInput
    {
        public string AttributeName { get; set; }
        public ObservableCollection<string> Values { get; set; } = new();
        public bool IsSelected { get; set; }
        public string SelectedValue { get; set; }
    }
}
