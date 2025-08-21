using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
	public static class CachKey
	{
		public static string GetPermissionKey(string userId) => "Permission_" + userId;
	}
}
