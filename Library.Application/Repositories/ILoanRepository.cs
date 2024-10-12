using Library.Core.Entities;

namespace Library.Application.Repositories
{
    public interface ILoanRepository : IBaseRepository<Loan>
    {
        Task<bool> ReturnAsync(Loan loan, DateTime returnDate,CancellationToken cancellation);
        Task<List<Loan>> GetByUser(Guid userId, CancellationToken cancellation);
    }
}
