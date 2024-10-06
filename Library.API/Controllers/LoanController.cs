using Library.API.Entities;
using Library.API.Repositories;

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
        public async Task<IEnumerable<Loan>> GetLoans()
        {
            return await _loanRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Loan> GetLoan(int id)
        {
            return await _loanRepository.GetByIdAsync(id);

        }

        [HttpPost]
        public async Task CreateLoan(Loan loan)
        {
            await _loanRepository.CreateAsync(loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoan(Loan loan)
        {
            var existingLoan = await _loanRepository.GetByIdAsync(loan.Id);
            if (existingLoan == null)
            {
                return NotFound();
            }
            await _loanRepository.UpdateAsync(loan);
            return Ok("Loan Upated");
        }

    }
}
