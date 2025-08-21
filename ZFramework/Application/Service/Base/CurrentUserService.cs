using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Base
{
	internal class CurrentUserService : ICurrentUserService
	{
		public int? UserId { get; private set; }
		public List<int>? Roles { get; private set; }
		public HashSet<ulong>? Permissions { get; private set; }


		public void SetUser(int? userId, HashSet<ulong>? permissions, List<int>? roles)
		{
			Permissions = permissions;
			UserId = userId;
			Roles = roles;
		}
	}
}
