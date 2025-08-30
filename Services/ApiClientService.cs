using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{
    public class ApiClientService
    {
        private readonly HttpClient _httpClient;

        public ApiClientService()
        {
            _httpClient = new HttpClient();
            // _httpClient.BaseAddress = new Uri("https://devtestapi.debtstream.co.uk/");//TODO: I'm using localhost for testing, because the devtestapi is not working. (timeout error)
            _httpClient.BaseAddress = new Uri("https://localhost:7152/"); 
            _httpClient.DefaultRequestHeaders.Add("Api-Key", "1234567890"); //TODO: Move to config
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}