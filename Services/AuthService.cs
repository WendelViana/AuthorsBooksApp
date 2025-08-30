using AuthorsBooksApp.Helpers;
using AuthorsBooksApp.Models;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{
    public class AuthService
    {
        private readonly ApiClientService _apiService;

        public AuthService()
        {
            _apiService = new ApiClientService();
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