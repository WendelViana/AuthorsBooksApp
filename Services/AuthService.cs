using AuthorsBooksApp.Helpers;
using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services.Interfaces;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApiClientService _apiService;

        public AuthService(IApiClientService apiClientService)
        {
            _apiService = apiClientService;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _apiService.GetAsync<User>($"Auth/GetUserByEmail/{email}");
        }

        public async Task<User> RegisterUser(User user)
        {
            user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash);

            return await _apiService.PostAsync<User>("Auth/RegisterUser", user);
        }
    }
}