using AuthorsBooksApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services.Interfaces
{
    public interface IBookService
    {
       Task<Book> AddBook(Book book);
       Task<List<Book>> GetAllBooks();
       Task<Book> UpdateBook(Book book);
       Task<Book> GetBookById(string id);
    }
}