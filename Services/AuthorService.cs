using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{
    public class AuthorService: IAuthorService
    {
        private readonly IApiClientService _apiService;

        public AuthorService(IApiClientService apiClientService)
        {
            _apiService = apiClientService;
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

        public async Task<Author> GetById(string Id)
        {
            return await _apiService.GetAsync<Author>($"Author/Get/{Id}");
        }
    }
}