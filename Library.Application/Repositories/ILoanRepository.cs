using Library.Core.Entities;

namespace Library.Application.Repositories
{
    public interface ILoanRepository : IBaseRepository<Loan>
    {

        //Cadastrar Data de Devolução
        //Devolver um Livro
        Task ReturnAsync(Loan loan, DateTime returnDate);


    }
}
