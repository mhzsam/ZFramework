using Domain.Shared.Models;
using Domain.Exception;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Shared.Message;
using Domain.Entites;

namespace Domain.Helper
{
	public static class SecurityHelper
	{
		private static AppSettings? _appSettings;

		public static void Configure(AppSettings? appSettings)
		{
			_appSettings = appSettings;
		}
		public static string PasswordToSHA256(string password)
		{
			StringBuilder Sb = new StringBuilder();
			using (SHA256 hash = SHA256.Create())
			{
				Encoding enc = Encoding.UTF8;
				byte[] result = hash.ComputeHash(enc.GetBytes(password));

				foreach (byte b in result)
					Sb.Append(b.ToString("x2"));
			}

			return Sb.ToString();
		}
		public static string GetNewToken(TokenClaim tokenClaim)
		{
			if (_appSettings == null)
				throw new CustomException(ErrorText.Auth.ConfigNotfound);

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(_appSettings.JWTConfig.TokenKey);



			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(tokenClaim.ToClaims()),
				Expires = DateTime.UtcNow.AddMinutes(_appSettings.JWTConfig.TokenTimeOut),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

	}
}
