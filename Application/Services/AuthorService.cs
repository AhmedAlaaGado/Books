using Application.Dtos;
using Application.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorDto>> GetAllAuthors()
        {
            return await _context.Authors
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();
        }
    }
}
