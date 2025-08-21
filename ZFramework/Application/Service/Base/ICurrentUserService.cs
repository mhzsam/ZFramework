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
		List<int>? Roles { get; }
		HashSet<ulong>? Permissions { get; }

		void SetUser(int? userId, HashSet<ulong>? permissions, List<int>? roles);
	}
}
