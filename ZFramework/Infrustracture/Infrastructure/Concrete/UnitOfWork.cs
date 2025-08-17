using Application.Interface;
using Domain.Context;
using Domain.Entites.Base;
using EFCore.BulkExtensions;
using Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private Dictionary<Type, object> _repositories;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<ET> GetRepository<ET>() where ET : EntityClass
        {
            if (_repositories.ContainsKey(typeof(ET)))
            {
                return (IRepository<ET>)_repositories[typeof(ET)];
            }

            var repository = new Repository<ET>(_context);
            _repositories[typeof(ET)] = repository;
            return repository;
        }
       
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public Task BulkSaveChangesAsync()
        {
            return _context.BulkSaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
        }

        public void RollbackTransaction()
        {
            try { _transaction?.Rollback(); } finally { _transaction.Dispose(); }
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
