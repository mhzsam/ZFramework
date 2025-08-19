using DocumentFormat.OpenXml.InkML;
using Domain.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Base
{
	public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
	{
		public readonly IApplicationDBContext _context;

		public readonly DbSet<TEntity> _dbSet;
		public BaseService(IApplicationDBContext applicationDBContext)
		{
			_context = applicationDBContext;

			_dbSet = _context.Set<TEntity>();
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
