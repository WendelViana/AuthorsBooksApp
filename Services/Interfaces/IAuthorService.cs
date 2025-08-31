using AuthorsBooksApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsBooksApp.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author> AddAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
        Task<Author> GetById(string Id);
    }
}