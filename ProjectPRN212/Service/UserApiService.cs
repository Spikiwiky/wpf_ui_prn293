using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;


namespace ProjectPRN212.Service
{
    public interface IUserApiService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int userId);
        Task<bool> CreateUserAsync(UserDto newUser);
        Task<bool> UpdateUserAsync(UserDto updatedUser);
        Task<bool> DeleteUserAsync(int userId);
    }

    public class UserApiService : IUserApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseEndpoint = "/api/Users";

        public UserApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        private JsonSerializerOptions JsonOptions => new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync(BaseEndpoint);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<UserDto>>(json, JsonOptions) ?? new();
        }

        public async Task<UserDto?> GetUserByIdAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"{BaseEndpoint}/{userId}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UserDto>(json, JsonOptions);
        }

        public async Task<bool> CreateUserAsync(UserDto newUser)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(BaseEndpoint, jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUserAsync(UserDto updatedUser)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(updatedUser), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{BaseEndpoint}/{updatedUser.UserId}", jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseEndpoint}/{userId}");
            return response.IsSuccessStatusCode;
        }
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Phone { get; set; }
        public string UserName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public DateTime CreateDate { get; set; }

        public int Status { get; set; }

        public bool IsDelete { get; set; }

        // public object Role { get; set; }
        // public List<object> Carts { get; set; }
        // public List<object> Orders { get; set; }
    }
}
