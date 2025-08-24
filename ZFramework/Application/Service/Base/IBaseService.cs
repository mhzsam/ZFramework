using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Base
{
	public interface IBaseService<TEntity> where TEntity : class
	{
		Task<TEntity?> GetByIdAsync(object id);
		Task<List<TEntity>> GetAllAsync();
		Task<TEntity> AddAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task DeleteAsync(TEntity entity);
		Task<PagingResponseModel<TEntity>?> GetPagedAsync(QueryParameters parameters, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);
		Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>>? predicate);
	}
}
