using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Interface
{
	public interface IDbContext
	{
		// Database operations
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		int SaveChanges();

		// Entry methods
		EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		EntityEntry Entry(object entity);
		// Database property
		DatabaseFacade Database { get; }
		// Change tracking
		ChangeTracker ChangeTracker { get; }
	}
}
