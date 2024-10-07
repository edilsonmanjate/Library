using Library.Core.Entities;

namespace Library.Infrastructure.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> GetByIdAsync(Guid id);

        Task<IEnumerable<Loan>> GetAllAsync();
        Task CreateAsync(Loan loan);

        Task UpdateAsync(Loan loan);

        //Cadastrar Data de Devolução
        //Devolver um Livro
        Task ReturnAsync(Loan loan, DateTime returnDate);

    }
}
