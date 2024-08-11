namespace Application.Dtos
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class AuthorViewModelExtensions
    {
        public static AuthorViewModel ToViewModel(this AuthorDto authorDto)
        {
            return new AuthorViewModel
            {
                Id = authorDto.Id,
                Name = authorDto.Name
            };
        }

        public static AuthorDto ToDto(this AuthorViewModel authorViewModel)
        {
            return new AuthorDto
            {
                Id = authorViewModel.Id,
                Name = authorViewModel.Name
            };
        }
    }
}
