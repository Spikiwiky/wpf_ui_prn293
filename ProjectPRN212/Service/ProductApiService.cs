using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectPRN212.Service
{
    public class ProductVariantDetail
    {
        [JsonPropertyName("size")]
        public string Size { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("material")]
        public string Material { get; set; }

        [JsonPropertyName("xuất sứ")]
        public string XuatXu { get; set; } // cần decode từ UTF-8

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("stock")]
        public int Stock { get; set; }
    }

    public class ProductVariant
    {
        public int VariantId { get; set; }
        public int ProductId { get; set; }
        public string Attributes { get; set; } // JSON string
        public List<ProductVariantDetail> Variants { get; set; }
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
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("ApiClient");
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<ProductDto>> GetPagedProductsAsync(int page = 1, int pageSize = 10)
        {
            var response = await _client.GetAsync($"api/Product?page={page}&pageSize={pageSize}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<ProductDto>>(json, _jsonOptions);
            }

            return null;
        }



        public async Task<List<ProductDto>> SearchProductsByNameAsync(string name, int page = 1, int pageSize = 50)
        {
            // Encode query param
            string encodedName = Uri.EscapeDataString(name);
            string url = $"api/Product/search?name={encodedName}&page={page}&pageSize={pageSize}";

            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<ProductDto>>(json, _jsonOptions);
            }

            return null;
        }



        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductDto>(json, _jsonOptions);
            }

            return null;
        }






    }




}
