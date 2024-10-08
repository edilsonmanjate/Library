namespace Library.Application.Repositories
{
    public interface IUnitOfWork
    {
        Task Save(CancellationToken cancellationToken);
    }
}
