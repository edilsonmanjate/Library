using Library.Application.Repositories;
using Library.Core.Entities;

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
        public async Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAll(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBook(Guid id, CancellationToken cancellationToken)
        {
            return await _bookRepository.Get(id,cancellationToken);

        }

        [HttpPost]
        public async Task CreateBook(Book book)
        {
           await _bookRepository.Create(book);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
           await _bookRepository.Update(book);
            return Ok("Book Upated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(Book book)
        {
            await _bookRepository.Delete(book);
            return Ok("Book Deleted");
        }

    }
}
