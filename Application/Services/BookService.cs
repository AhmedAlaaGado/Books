using Application.Dtos;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author.Name,
                    PublisherId = b.PublisherId,
                    PublisherName = b.Publisher.Name,
                    Genre = b.Genre,
                    PublishedYear = b.PublishedYear
                })
                .ToListAsync();
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                AuthorName = book.Author.Name,
                PublisherId = book.PublisherId,
                PublisherName = book.Publisher.Name,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear
            };
        }

        public async Task AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
                PublisherId = bookDto.PublisherId,
                Genre = bookDto.Genre,
                PublishedYear = bookDto.PublishedYear
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBook(BookDto bookDto)
        {
            var book = await _context.Books.FindAsync(bookDto.Id);
            if (book == null) return;

            book.Title = bookDto.Title;
            book.AuthorId = bookDto.AuthorId;
            book.PublisherId = bookDto.PublisherId;
            book.Genre = bookDto.Genre;
            book.PublishedYear = bookDto.PublishedYear;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
