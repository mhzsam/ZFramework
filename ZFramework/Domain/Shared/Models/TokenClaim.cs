using Domain.Entites;
using System.Security.Claims;

namespace Domain.Shared.Models
{
	public class TokenClaim
	{
		public TokenClaim(int id, List<Role>? roles=null, Dictionary<string, string>? customClaims = null)
		{

			Id = id;
			Roles = roles;
			CustomClaims = customClaims;
		}

		private int Id { get; set; }
		private List<Role>? Roles { get; set; }
		private Dictionary<string, string>? CustomClaims { get; set; }
		public List<Claim> ToClaims()
		{
			var claims = new List<Claim>();

			if (Roles != null)
			{
				foreach (var role in Roles)
				{
					// اگه Role کلاس توی سیستم کلاس معمولی هست، اسمش یا Idش رو بگذار
					claims.Add(new Claim("Roles", string.Join(",", Roles.Select(s => s.Id).ToList())));
					// یا مثلا:
					// claims.Add(new Claim("roleId", role.Id.ToString()));
				}
			}

			// Claims سفارشی
			if (CustomClaims != null)
			{
				foreach (var kvp in CustomClaims)
				{
					claims.Add(new Claim(kvp.Key, kvp.Value));
				}
			}

			claims.Add(new Claim("userId", Id.ToString()));

			return claims;
		}
	}


}
