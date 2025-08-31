using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{
    public interface IApiClientService
    {
        Task<T> GetAsync<T>(string endpoint);
        Task<T> PostAsync<T>(string endpoint, object data);
    }
}