using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
	public static class StaticKey
	{
		public static string GetPermissionKey(string userId) => "Permission_" + userId;
		public static string GetUserClaimKey() => "userId";
		public static string GetUserRolesClaimKey() => "Roles";
	}


}
