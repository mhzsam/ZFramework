using Application.Interface;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Domain.Context;
using Domain.Entites.Base;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generic
{
    public class Repository<T> : IRepository<T> where T : EntityClass
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> _entities;
        string _errorMessage = string.Empty;

        public Repository(ApplicationDBContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public Task<T?> GetAsync(long id)
        {
            var result = _entities.SingleOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public Task<List<T>> GetAllAsync(int page, int rowPerPage)
        {
            if (page > 0)
            {
                page = page - 1;
            }

            return _entities.Skip(page* rowPerPage).Take(rowPerPage).AsNoTracking().ToListAsync();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public Task<T?> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate).FirstOrDefaultAsync();
        }

        public  Task BulkInsertAsync(List<T> lst)
        {
           return  _context.BulkInsertAsync<T>(lst);
            
        }

        public Task BulkUpdateAsync(List<T> lst)
        {
            return _context.BulkUpdateAsync<T>(lst);
        }

        public async Task<int> TotalRecords()
        {
            return await _entities.AsNoTracking().CountAsync();
        }
    }
}
