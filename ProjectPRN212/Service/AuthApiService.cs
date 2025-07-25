using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN212.Service
{
    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string message { get; set; }
        public string token { get; set; }
        public int userId { get; set; }
        public string roleName { get; set; }
        public string userName { get; set; }
    }

    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }

    public class RegisterResponseDto
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
    }

    public class AuthApiService
    {
        private readonly HttpClient _client;

        public AuthApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginDto)
        {
            var response = await _client.PostAsJsonAsync("api/Auth/login", loginDto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            }
            return null;
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto registerDto)
        {
            var response = await _client.PostAsJsonAsync("api/Auth/register", registerDto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RegisterResponseDto>();
            }
            return null;
        }


    }



}
