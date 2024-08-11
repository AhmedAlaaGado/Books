using Application.Dtos;
using Application.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _context;

        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PublisherDto>> GetAllPublishers()
        {
            return await _context.Publishers
                .Select(p => new PublisherDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
        }
    }
}
