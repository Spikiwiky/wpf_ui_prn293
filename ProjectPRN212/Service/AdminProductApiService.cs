using ProjectPRN212.GUI.Page_Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectPRN212.Service
{
    public class AdminProductApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public AdminProductApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync(int page = 1, int pageSize = 10)
        {
            var response = await _httpClient.GetAsync($"/api/product?page={page}&pageSize={pageSize}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProductDTO>>(content, _jsonOptions) ?? new List<ProductDTO>();
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/product/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductDTO>(content, _jsonOptions);
        }

        public async Task<List<ProductDTO>> SearchProductsAsync(ProductSearchParams searchParams)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(searchParams.Name))
                queryParams.Add($"name={Uri.EscapeDataString(searchParams.Name)}");

            if (!string.IsNullOrEmpty(searchParams.Category))
                queryParams.Add($"category={Uri.EscapeDataString(searchParams.Category)}");

            if (searchParams.Attributes?.Any() == true)
                queryParams.Add($"attributes={Uri.EscapeDataString(JsonSerializer.Serialize(searchParams.Attributes))}");

            if (searchParams.MinPrice.HasValue)
                queryParams.Add($"minPrice={searchParams.MinPrice}");

            if (searchParams.MaxPrice.HasValue)
                queryParams.Add($"maxPrice={searchParams.MaxPrice}");

            if (searchParams.Page.HasValue)
                queryParams.Add($"page={searchParams.Page}");

            queryParams.Add($"pageSize={searchParams.PageSize ?? 10}");
            var queryString = string.Join("&", queryParams);

            var response = await _httpClient.GetAsync($"/api/product/search?{queryString}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonSerializer.Deserialize<List<ProductDTO>>(content, _jsonOptions) ?? new List<ProductDTO>();

            // Filter by attribute match
            if (searchParams.Attributes?.Any() == true)
            {
                products = products.Where(p => p.Variants.Any(v =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(v.Attributes)) return false;
                        var variantAttributes = JsonSerializer.Deserialize<Dictionary<string, string>>(v.Attributes);
                        return searchParams.Attributes.All(a =>
                            variantAttributes.TryGetValue(a.Key, out var value) && value == a.Value);
                    }
                    catch { return false; }
                })).ToList();
            }

            return products;
        }

        public async Task<int> GetTotalProductsCountAsync(string? name = null, string? category = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var queryParams = new List<string>();
            if (!string.IsNullOrEmpty(name)) queryParams.Add($"name={Uri.EscapeDataString(name)}");
            if (!string.IsNullOrEmpty(category)) queryParams.Add($"category={Uri.EscapeDataString(category)}");
            if (minPrice.HasValue) queryParams.Add($"minPrice={minPrice}");
            if (maxPrice.HasValue) queryParams.Add($"maxPrice={maxPrice}");

            var response = await _httpClient.GetAsync($"/api/product/count?{string.Join("&", queryParams)}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<int>(content, _jsonOptions);
        }

        public async Task<bool> CreateProductAsync(ProductDTO product)
        {
            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/admin/products", content);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<bool>(await response.Content.ReadAsStringAsync(), _jsonOptions);
        }
       
        public async Task<bool> UpdateProductAsync(int id, ProductDTO product)
        {
            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/admin/products/{id}", content);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<bool>(await response.Content.ReadAsStringAsync(), _jsonOptions);
        }

        public async Task<bool> AddProductImageAsync(int productId, string imageUrl)
        {
            var request = new { imageUrl };
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/product/{productId}/images", content);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<bool>(await response.Content.ReadAsStringAsync(), _jsonOptions);
        }

        public async Task<string?> UploadProductImageAsync(int productId, string imagePath)
        {
            try
            {
                using var formData = new MultipartFormDataContent();
                using var fileStream = File.OpenRead(imagePath);
                formData.Add(new StreamContent(fileStream), "imageFile", Path.GetFileName(imagePath));
                formData.Add(new StringContent(productId.ToString()), "productId");

                var response = await _httpClient.PostAsync("/api/product/upload-image", formData);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<UploadImageResponse>(responseContent, _jsonOptions);
                return result?.ImageUrl;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> SaveProductVariantAsync(ProductVariantDTO variant)
        {
            var content = new StringContent(JsonSerializer.Serialize(variant), Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            if (variant.VariantId.HasValue)
            {
                // Update
                response = await _httpClient.PutAsync($"/api/admin/products/{variant.ProductId}/variants/{variant.VariantId}", content);
            }
            else
            {
                // Create
                response = await _httpClient.PostAsync($"/api/admin/products/{variant.ProductId}/variants", content);
            }

            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<bool>(await response.Content.ReadAsStringAsync(), _jsonOptions);
        }

        // GET all variants of a product
        public async Task<List<ProductVariantDTO>> GetProductVariantsAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"/api/products/{productId}/variants");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProductVariantDTO>>(content, _jsonOptions) ?? new();
        }


        public async Task<bool> AddProductVariantAsync(ProductVariantDTO variant)
        {
            var json = JsonSerializer.Serialize(variant, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/products/variants", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductVariantAsync(ProductVariantDTO variant)
        {
            if (variant.VariantId == null)
                return false;

            var json = JsonSerializer.Serialize(variant, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/products/variants/{variant.VariantId}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductVariantAsync(int variantId)
        {
            var response = await _httpClient.DeleteAsync($"/api/products/variants/{variantId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVariantValueAsync(int variantId, int valueIndex)
        {
            var response = await _httpClient.DeleteAsync($"/api/products/variants/{variantId}/values/{valueIndex}");
            return response.IsSuccessStatusCode;
        }









        public static ProductVariantDTO ConvertToApiVariant(VariantDTO variant, int productId)
        {
            var variantDict = new Dictionary<string, object>
    {
        { variant.AttributeName, variant.Values.ToList() }
    };

            return new ProductVariantDTO
            {
                ProductId = productId,
                Attributes = JsonSerializer.Serialize(variantDict),
                Variants = new List<Dictionary<string, object>> { variantDict }
            };
        }



        public class UploadImageResponse
        {
            public string ImageUrl { get; set; } = string.Empty;
        }




        public class ProductDTO
        {
            public int ProductId { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Brand { get; set; } = string.Empty;
            public decimal BasePrice { get; set; }
            public string AvailableAttributes { get; set; } = string.Empty;
            public int CategoryId { get; set; }
            public string? CategoryName { get; set; }
            public List<string> Images { get; set; } = new();
            public List<ProductVariantDTO> Variants { get; set; } = new();
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

            public List<string> GetFullImageUrls(string apiBaseUrl)
            {
                return Images.Select(img => GetFullImageUrl(img, apiBaseUrl)).ToList();
            }

            public string GetFirstImageUrl(string apiBaseUrl)
            {
                return Images.Any() ? GetFullImageUrl(Images.First(), apiBaseUrl) : string.Empty;
            }

            private string GetFullImageUrl(string imageUrl, string apiBaseUrl)
            {
                if (string.IsNullOrEmpty(imageUrl))
                    return string.Empty;

                if (imageUrl.StartsWith("http://") || imageUrl.StartsWith("https://"))
                    return imageUrl;

                return $"{apiBaseUrl.TrimEnd('/')}/{imageUrl.TrimStart('/')}";
            }
        }

        public class ProductVariantDTO
        {
            public int? VariantId { get; set; }
            public int ProductId { get; set; }
            public string Attributes { get; set; } = string.Empty;
            public List<Dictionary<string, object>> Variants { get; set; } = new();
            public object Values { get; internal set; }
        }

        public class ProductSearchParams
        {
            public string? Name { get; set; }
            public string? Category { get; set; }
            public Dictionary<string, string>? Attributes { get; set; }
            public decimal? MinPrice { get; set; }
            public decimal? MaxPrice { get; set; }
            public int? Page { get; set; }
            public int? PageSize { get; set; }
        }

        public class VariantDTO
        {
            public string AttributeName { get; set; } = string.Empty;
            public ObservableCollection<string> Values { get; set; } = new();
        }

    }
}
