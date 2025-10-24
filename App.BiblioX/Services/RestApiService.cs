using System.Text.Json;

namespace App.BiblioX.Services
{
    public class RestApiService
    {
        private readonly HttpClient _client = new();
        private string _baseUrl = string.Empty;
        
        public RestApiService()
        {
            _baseUrl = GetBaseUrl();
            _client = new HttpClient { BaseAddress = new Uri( _baseUrl) };
        }

        public async Task<T> GetAsync<T>(string endpoint)  where T : class, new()
        {    
            try
            {
                var response = await _client.GetAsync(endpoint);

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

        public string GetBaseUrl()
        {
            try
            {
                var path = Path.Combine(AppContext.BaseDirectory, "AppSettings.json");

                if (!File.Exists(path))
                {
                    Console.WriteLine("RestApiService: AppSettings.json introuvable");
                    return "https://fallback.url/";
                }

                var json = File.ReadAllText(path);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("Api", out var apiSection) &&
                    apiSection.TryGetProperty("BaseUrl", out var baseUrl))
                {
                    return baseUrl.GetString() ?? "https://fallback.url/";
                }

                Console.WriteLine("RestApiService: Clé 'Api:BaseUrl' introuvable");
                return "https://fallback.url/";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RestApiService: Erreur lecture config → {ex.Message}");
                return "https://fallback.url/";
            }
        }
    }
}





