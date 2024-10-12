using Library.Application.Features.Users.Commands.CreateUserCommand;
using Library.Application.Features.Users.Queries.GetAllUsersQuery;
using Library.Application.Features.Users.Queries.GetUserByIdQuery;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());
            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (command == null) return BadRequest();

            var response = await _mediator.Send(command, cancellationToken);

            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetAsync([FromQuery] Guid userId)
        {
            var response = await _mediator.Send(new GetUserByIdQuery() { UserId = userId });
            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
