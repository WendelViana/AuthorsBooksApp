using AuthorsBooksApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{
    public class AuthorService
    {
        private readonly ApiClientService _apiService;

        public AuthorService()
        {
            _apiService = new ApiClientService();
        }


        public async Task<List<Author>> GetAllAuthors()
        {
            return await _apiService.GetAsync<List<Author>>("Author/GetAll");
        }

        public async Task<Author> AddAuthor(Author author)
        {
            return await _apiService.PostAsync<Author>("Author/Add", author);
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            return await _apiService.PostAsync<Author>($"Author/Edit", author);
        }
    }
}