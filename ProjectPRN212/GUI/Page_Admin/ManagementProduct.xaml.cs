using ProjectPRN212.Service;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static ProjectPRN212.Service.AdminProductApiService;
namespace ProjectPRN212.GUI.Page_Admin
{
    public partial class ProductManagementWindow : Window, INotifyPropertyChanged
    {
        private readonly AdminProductApiService _productService;
        private List<ProductDTO> _products = new();
        private int _currentPage = 1;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<ProductDTO> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public ProductManagementWindow(AdminProductApiService productService)
        {
            InitializeComponent();
            _productService = productService;
            DataContext = this; 
            _ = LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
            Products = await _productService.GetAllProductsAsync(CurrentPage);
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button?.Tag as ProductDTO;

            if (product != null)
            {
                var editWindow = new ProductEditWindow(_productService, product); // pass service and product
                bool? result = editWindow.ShowDialog(); // open as modal dialog

                if (result == true)
                {
                    // Optionally reload product list or update UI
                    await LoadProductsAsync(); // assuming you have this method
                }
            }
        }


        private void Details_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button?.Tag as ProductDTO;

            if (product != null)
            {
                
                    var detailsWindow = new ProductDetailsWindow(product);
                    detailsWindow.Owner = this;
                    detailsWindow.ShowDialog();
                
            }
        }

        private void Variants_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button?.Tag as ProductDTO;

            if (product != null)
            {
                // TODO: Show variants for product
                MessageBox.Show($"Variants for product: {product.Name}");
            }
        }

        private async void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                await LoadProductsAsync();
            }
        }

        private async void NextPage_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.RoleName = null;
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();
        }


    }
}
