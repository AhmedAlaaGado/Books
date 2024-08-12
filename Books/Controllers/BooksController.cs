using Application.Dtos;
using Application.Interfaces;
using Books.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public BooksController(IBookService bookService, IAuthorService authorService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 2)
        {
            var (books, totalCount) = await _bookService.GetAllBooks(pageNumber, pageSize);

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var viewModel = new BookListViewModel
            {
                Books = books.Select(b => b.ToViewModel()).ToList(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var authors = await _authorService.GetAllAuthors();
            var publishers = await _publisherService.GetAllPublishers();

            var viewModel = new BookViewModel
            {
                Authors = authors.Select(a => a.ToViewModel()).ToList(),
                Publishers = publishers.Select(p => p.ToViewModel()).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddBook(viewModel.ToDto());
                return RedirectToAction(nameof(Index));
            }

            viewModel.Authors = (await _authorService.GetAllAuthors()).Select(a => a.ToViewModel()).ToList();
            viewModel.Publishers = (await _publisherService.GetAllPublishers()).Select(p => p.ToViewModel()).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var authors = await _authorService.GetAllAuthors();
            var publishers = await _publisherService.GetAllPublishers();

            var viewModel = book.ToViewModel();
            viewModel.Authors = authors.Select(a => a.ToViewModel()).ToList();
            viewModel.Publishers = publishers.Select(p => p.ToViewModel()).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBook(viewModel.ToDto());
                return RedirectToAction(nameof(Index));
            }

            viewModel.Authors = (await _authorService.GetAllAuthors()).Select(a => a.ToViewModel()).ToList();
            viewModel.Publishers = (await _publisherService.GetAllPublishers()).Select(p => p.ToViewModel()).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = book.ToViewModel();
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
