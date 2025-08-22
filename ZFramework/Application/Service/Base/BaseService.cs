using Domain.Shared.Interface;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Service.Base
{
	public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
	{
		protected readonly IApplicationDBContext _context;

		protected readonly DbSet<TEntity> _dbSet;
		protected readonly ICurrentUserService _currentUser;
		public BaseService(IApplicationDBContext applicationDBContext, ICurrentUserService currentUser)
		{
			_context = applicationDBContext;

			_dbSet = _context.Set<TEntity>();
			_currentUser = currentUser;
		}
		public virtual async Task<PagingResponseModel<TEntity>?> GetPagedAsync(QueryParameters parameters, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
		{
			var query = _dbSet.AsQueryable();
			if (includes != null)
				query = includes(query);

			var result = query.ApplyQuery(parameters);
			var data = await result.ToListAsync();
			var totalCount = await _dbSet.CountAsync();
			if (data == null)
				PagingResponseModel<TEntity>.Success();

			return PagingResponseModel<TEntity>.Success(data, totalCount, parameters.Page, parameters.PageSize);
		}

		public virtual async Task<TEntity?> GetByIdAsync(object id)
		{
			return await _dbSet.FindAsync(id);
		}

		public virtual async Task<List<TEntity>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			await SaveChangesAsync();
			return entity;
		}

		public virtual async Task UpdateAsync(TEntity entity)
		{
			_dbSet.Update(entity);
			await SaveChangesAsync();
		}

		public virtual async Task DeleteAsync(TEntity entity)
		{
			_dbSet.Remove(entity);
			await SaveChangesAsync();
		}
		public virtual async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
		public virtual void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
