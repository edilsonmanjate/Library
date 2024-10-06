using Library.API.Entities;

namespace Library.API.Repositories
{
    public interface ILoanRepository
    {
        Task<Loan> GetByIdAsync(int id);

        Task<IEnumerable<Loan>> GetAllAsync();
        Task CreateAsync(Loan loan);

        Task UpdateAsync(Loan loan);

        //Cadastrar Data de Devolução
        //Devolver um Livro
        Task ReturnAsync(Loan loan, DateTime returnDate);

    }
}
