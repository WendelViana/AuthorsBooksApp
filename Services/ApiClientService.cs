using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{
    public class ApiClientService : IApiClientService
    {
        private readonly HttpClient _httpClient;

        public ApiClientService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true //ignoring ssl errors dev environment.
            };

            _httpClient = new HttpClient(handler);

            var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            var apiKey = ConfigurationManager.AppSettings["ApiKey"];

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("ApiBaseUrl is not configured in web.config.");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException("ApiKey is not configured in web.config.");

            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Add("API-Key", apiKey);
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return default;
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(data, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
                
            return default;
        }
    }
}