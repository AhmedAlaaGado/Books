using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooks();
        Task<BookDto> GetBookById(int id);
        Task AddBook(BookDto book);
        Task UpdateBook(BookDto book);
        Task DeleteBook(int id);
    }
}
