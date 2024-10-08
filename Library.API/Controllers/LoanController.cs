using Library.Application.Repositories;
using Library.Core.Entities;

using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/Loans")]
    public class LoanController : ControllerBase
    {
        private ILoanRepository _loanRepository;

        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Loan>> GetLoans(CancellationToken cancellationToken)
        {
            return await _loanRepository.GetAll(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<Loan> GetLoan(Guid id, CancellationToken cancellationToken)
        {
            return await _loanRepository.Get(id, cancellationToken);

        }

        [HttpPost]
        public async Task CreateLoan(Loan loan)
        {
            await _loanRepository.Create(loan);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLoan(Loan loan)
        {
            var cancellationToken = new CancellationToken();    
            var existingLoan = await _loanRepository.Get(loan.Id, cancellationToken);
            if (existingLoan == null)
            {
                return NotFound();
            }
            await _loanRepository.Update(loan);
            return Ok("Loan Upated");
        }

    }
}
