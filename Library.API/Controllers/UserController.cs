using Library.Application.DTOs;
using Library.Application.Features.Users.Commands.CreateUserCommand;
using Library.Application.Features.Users.Queries.GetAllUsersQuery;
using Library.Application.Features.Users.Queries.GetUserByIdQuery;
using Library.Infrastructure.Services.Auth;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly JwtService _jwtService;

        private readonly IMediator _mediator;

        public UserController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto user)
        {
            
            var userRoles = new List<string> { "Admin" }; 

            var token = _jwtService.GenerateToken(user.Username, userRoles);

            return Ok(new { Token = token });
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());
            if (response.Success)
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

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetAsync([FromQuery] Guid userId)
        {
            var response = await _mediator.Send(new GetUserByIdQuery() { UserId = userId });
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
