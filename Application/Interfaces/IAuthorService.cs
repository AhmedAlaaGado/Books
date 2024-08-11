using Application.Dtos;

namespace Application.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthors();
    }
}
