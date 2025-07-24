using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectPRN212.Service
{
    public class VariantDetail
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class ProductVariant
    {
        public int VariantId { get; set; }
        public int ProductId { get; set; }
        public string Attributes { get; set; } // JSON string: { "size": [...], "color": [...] }
        public List<VariantDetail> Variants { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal BasePrice { get; set; }
        public string AvailableAttributes { get; set; } // JSON string
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> Images { get; set; }
        public List<ProductVariant> Variants { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class ProductApiService
    {
        private readonly HttpClient _client;

        public ProductApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("ApiClient");
        }

        // Lấy danh sách sản phẩm có phân trang
        public async Task<List<ProductDto>> GetProductsAsync(int page = 1, int pageSize = 10)
        {
            var response = await _client.GetAsync($"api/Product?page={page}&pageSize={pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<ProductDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return null;
        }






    }
}
