using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{

    public class BookService : IBookService
    {
        private readonly IApiClientService _apiService;

        public BookService(IApiClientService apiClientService)
        {
            _apiService = apiClientService;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _apiService.GetAsync<List<Book>>("Book/GetAll");
        }

        public async Task<Book> GetBookById(string id)
        {
            return await _apiService.GetAsync<Book>($"Book/Get/{id}");
        }

        public async Task<Book> AddBook(Book book)
        {
            return await _apiService.PostAsync<Book>("Book/Add", book);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            return await _apiService.PostAsync<Book>($"Book/Edit", book);
        }
    }
}