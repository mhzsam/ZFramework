using Domain.Entites.Base;

namespace Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ET> GetRepository<ET>() where ET : EntityClass;

        IMovieRepository GetMovieRepository(); 

        Task BeginTransactionAsync();

        void CommitTransaction();

        void RollbackTransaction();

        Task<int> SaveChangesAsync();

        Task BulkSaveChangesAsync();

        void Dispose(bool disposing);
    }
}
