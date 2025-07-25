
using ProjectPRN212.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static ProjectPRN212.Service.AdminProductApiService;

namespace ProjectPRN212.GUI.ViewModels
{
    public class ProductManagementViewModel : INotifyPropertyChanged
    {
        private readonly AdminProductApiService _productService;

        public ObservableCollection<ProductDTO> Products { get; set; } = new ObservableCollection<ProductDTO>();

        private int _currentPage = 1;
        public int CurrentPage
        {
            get => _currentPage;
            set { _currentPage = value; OnPropertyChanged(); }
        }

        public int PageSize { get; set; } = 20;

        private int _totalPages;
        public int TotalPages
        {
            get => _totalPages;
            set { _totalPages = value; OnPropertyChanged(); }
        }

        public ProductSearchParams? SearchParams { get; set; }

        public ProductManagementViewModel(AdminProductApiService productService)
        {
            _productService = productService;
        }

        public async Task LoadProductsAsync(string? name = null, string? category = null)
        {
            SearchParams = new ProductSearchParams
            {
                Name = name,
                Category = category
            };

            var products = await _productService.GetAllProductsAsync(CurrentPage, PageSize);
            Products.Clear();
            foreach (var product in products)
                Products.Add(product);

            int total = await _productService.GetTotalProductsCountAsync(name, category);
            TotalPages = (int)Math.Ceiling(total / (double)PageSize);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
