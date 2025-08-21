using Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService
{

	public class BaseApplicationService
	{
		protected readonly IApplicationDBContext _context;

		public BaseApplicationService(IApplicationDBContext applicationDBContext)
		{
			_context = applicationDBContext ?? throw new ArgumentNullException(nameof(applicationDBContext));

		}
		public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
		{
			await _context.Database.BeginTransactionAsync(cancellationToken);
		}

		public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
		{
			await _context.Database.CommitTransactionAsync(cancellationToken);
		}

		public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
		{
			await _context.Database.RollbackTransactionAsync(cancellationToken);
		}
	}
}
