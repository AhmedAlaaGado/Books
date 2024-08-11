namespace Application.Dtos
{
    public class PublisherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class PublisherViewModelExtensions
    {
        public static PublisherViewModel ToViewModel(this PublisherDto publisherDto)
        {
            return new PublisherViewModel
            {
                Id = publisherDto.Id,
                Name = publisherDto.Name
            };
        }

        public static PublisherDto ToDto(this PublisherViewModel publisherViewModel)
        {
            return new PublisherDto
            {
                Id = publisherViewModel.Id,
                Name = publisherViewModel.Name
            };
        }
    }
}
