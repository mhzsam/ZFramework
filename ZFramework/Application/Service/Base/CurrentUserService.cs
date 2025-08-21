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
		public IReadOnlyCollection<int>? Roles { get; private set; } = Array.Empty<int>();

		public void SetUser(int? userId, IEnumerable<int> roles)
		{
			UserId = userId;
			Roles = roles.ToList();
		}
	}
}
