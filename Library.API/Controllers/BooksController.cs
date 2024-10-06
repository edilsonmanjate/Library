using Library.API.Entities;
using Library.API.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBook(int id)
        {
            return await _bookRepository.GetByIdAsync(id);

        }

        [HttpPost]
        public async Task CreateBook(Book book)
        {
           await _bookRepository.CreateAsync(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var existingBook = await _bookRepository.GetByIdAsync(book.Id);
            if (existingBook == null)
            {
                return NotFound();
            }
            await _bookRepository.UpdateAsync(book);
            return Ok("Book Upated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            await _bookRepository.DeleteAsync(id);
            return Ok("Book Deleted");
        }


    }
}
