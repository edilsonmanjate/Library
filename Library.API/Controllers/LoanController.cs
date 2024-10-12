using Library.Application.Features.Loans.Commands.CreateLoanCommand;
using Library.Application.Features.Loans.Commands.ReturnLoanCommand;
using Library.Application.Features.Loans.Commands.UpdateLoanCommand;
using Library.Application.Features.Loans.Queries.GetAllLoansQuery;
using Library.Application.Features.Loans.Queries.GetLoanByIdQuery;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/Loans")]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllLoanQuery());
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAsync([FromQuery] Guid loanId)
        {
            var response = await _mediator.Send(new GetLoanByIdQuery() { LoanId = loanId });
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CreateLoanCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateLoanCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("ReturnBook")]
        public async Task<ActionResult> ReturnBook([FromBody] ReturnLoanCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}
