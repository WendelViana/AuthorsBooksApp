using AuthorsBooksApp.Models;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> GetUserByEmail(string email);
        Task<User> RegisterUser(User user);

    }
}