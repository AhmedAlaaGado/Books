using Application.Dtos;

namespace Books.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public int PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }

        public List<AuthorViewModel> Authors { get; set; } = new List<AuthorViewModel>();
        public List<PublisherViewModel> Publishers { get; set; } = new List<PublisherViewModel>();
    }

    public static class BookViewModelExtensions
    {
        public static BookViewModel ToViewModel(this BookDto dto)
        {
            return new BookViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                AuthorId = dto.AuthorId,
                AuthorName = dto.AuthorName,
                PublisherId = dto.PublisherId,
                PublisherName = dto.PublisherName,
                Genre = dto.Genre,
                PublishedYear = dto.PublishedYear
            };
        }

        public static BookDto ToDto(this BookViewModel viewModel)
        {
            return new BookDto
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                AuthorId = viewModel.AuthorId,
                PublisherId = viewModel.PublisherId,
                Genre = viewModel.Genre,
                PublishedYear = viewModel.PublishedYear
            };
        }
    }
}
