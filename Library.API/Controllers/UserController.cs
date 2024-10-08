using Library.Application.DTOs;
using Library.Application.Repositories;
using Library.Core.Entities;

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

        //[HttpGet]
        //public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new Get(), cancellationToken);
        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(userInputModel request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
