using Domain.Entites.Base;
using System.Linq.Expressions;

namespace Application.Interface
{
    public interface IRepository<T> where T : EntityClass
    {
        Task<int> TotalRecords();
        Task<List<T>> GetAllAsync(int page, int rowPerPage);
        Task<T?> GetAsync(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task BulkInsertAsync(List<T> lst);
        Task BulkUpdateAsync(List<T> lst);
        Task<T?> FindByAsync(Expression<Func<T, bool>> predicate);
    }
}
