using Application.Dtos;

namespace Application.Interfaces
{
    public interface IPublisherService
    {
        Task<List<PublisherDto>> GetAllPublishers();
    }
}
