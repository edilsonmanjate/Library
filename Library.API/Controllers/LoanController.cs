using Library.Application.Features.Loans.Commands.CreateLoanCommand;
using Library.Application.Features.Loans.Commands.ReturnLoanCommand;
using Library.Application.Features.Loans.Commands.UpdateLoanCommand;
using Library.Application.Features.Loans.Queries.GetAllLoansQuery;
using Library.Application.Features.Loans.Queries.GetLoanByIdQuery;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Threading;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/Loans")]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController( IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
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
            if (_mediator == null)
            {
                throw new InvalidOperationException("_mediator is not initialized.");
            }

            var response = await _mediator.Send(new GetLoanByIdQuery() { LoanId = loanId });
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CreateLoanCommand command, CancellationToken cancellationToken)
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
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateLoanCommand command, CancellationToken cancellationToken)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command,cancellationToken);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("ReturnBook")]
        public async Task<ActionResult> ReturnBook([FromBody] ReturnLoanCommand command, CancellationToken cancellationToken)
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
