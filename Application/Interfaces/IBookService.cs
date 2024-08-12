using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<(List<BookDto> Books, int TotalCount)> GetAllBooks(int pageNumber, int pageSize);
        Task<BookDto> GetBookById(int id);
        Task AddBook(BookDto book);
        Task UpdateBook(BookDto book);
        Task DeleteBook(int id);
    }
}
