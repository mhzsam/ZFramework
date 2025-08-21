using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Models
{
	public class AppSettings
	{
		public JwtConfig JWTConfig { get; set; } = new();
		public ConnectionStrings ConnectionStrings { get; set; } = new();
		public Logging Logging { get; set; } = new();
		public ProjectDetails ProjectDetails { get; set; } = new();
		public CacheSettings CacheSettings { get; set; } = new();
	}
	public class CacheSettings
	{
		public string Provider { get; set; } = "Memory";
		public string RedisConfiguration { get; set; }
		public int DefaultExpirationSeconds { get; set; } = 300;
	}
	public class JwtConfig
	{
		public string TokenKey { get; set; }
		public int TokenTimeOut { get; set; }
	}
	public class ConnectionStrings
	{
		public string SqlConnection { get; set; } = string.Empty;
	}
	public class Logging
	{
		public LogLevel LogLevel { get; set; } = new();
	}

	public class LogLevel
	{
		public string Default { get; set; } = string.Empty;
		public string MicrosoftAspNetCore { get; set; } = string.Empty;
	}
	public class ProjectDetails
	{
		public string Title { get; set; } = string.Empty;
		public int? version { get; set; } = null;
	}
}
