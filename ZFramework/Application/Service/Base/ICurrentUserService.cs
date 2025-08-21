using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Base
{
	public interface ICurrentUserService
	{
		int? UserId { get; }
		IReadOnlyCollection<int>? Roles { get; }

		void SetUser(int? userId, IEnumerable<int> roles);
	}
}
