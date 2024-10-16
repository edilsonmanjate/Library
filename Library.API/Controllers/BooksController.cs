using Library.Application.Features.Books.Commands.CreateBookCommand;
using Library.Application.Features.Books.Commands.DeleteBookCommand;
using Library.Application.Features.Books.Commands.UpdateBookCommand;
using Library.Application.Features.Books.Queries.GetAllBooksQuery;
using Library.Application.Features.Books.Queries.GetBookByIdQuery;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    [OutputCache]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllBooksQuery());
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAsync([FromQuery] Guid bookId)
        {
            var response = await _mediator.Send(new GetBookByIdQuery() { BookId = bookId });
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CreateBookCommand command, CancellationToken cancellationToken)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command, cancellationToken);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateBookCommand command, CancellationToken cancellationToken)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command, cancellationToken);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteBookCommand command, CancellationToken cancellationToken)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command, cancellationToken);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}

