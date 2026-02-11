using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace App.BiblioX.Services
{
    public class RestApiService
    {
        private readonly HttpClient _httpClient = new();
        private string _baseUrl = string.Empty;
        
        public RestApiService(IConfiguration config)
        {
            _baseUrl = config["Api:BaseUrl"] ?? "https://fallback.url/"; 
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }

        public async Task<T> GetAsync<T>(string endpoint)  where T : class, new()
        {    
            try
            {
                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(content) ?? new T();

                }
                else
                {
                    Console.WriteLine($"ApiService : {response.StatusCode}");
                    return new T();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ApiService: Erreur avec {endpoint} → {ex.Message}");
                return new T(); 
            }
        }
    }
}





