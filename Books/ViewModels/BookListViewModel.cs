namespace Books.ViewModels
{
    public class BookListViewModel
    {
        public List<BookViewModel> Books { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
