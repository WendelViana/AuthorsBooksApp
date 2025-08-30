using AuthorsBooksApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services
{

    public class BookService
    {
        private readonly ApiClientService _apiService;

        public BookService()
        {
            _apiService = new ApiClientService();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _apiService.GetAsync<List<Book>>("Book/GetAll");
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