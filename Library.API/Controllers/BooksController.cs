using Library.Core.Entities;
using Library.Infrastructure.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    //[OutputCache]
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
        public async Task<Book> GetBook(Guid id)
        {
            return await _bookRepository.GetByIdAsync(id);

        }

        [HttpPost]
        public async Task CreateBook(Book book)
        {
           await _bookRepository.CreateAsync(book);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
           await _bookRepository.UpdateAsync(book);
            return Ok("Book Upated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
            return Ok("Book Deleted");
        }

    }
}
