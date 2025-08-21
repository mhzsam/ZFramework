using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AplicationDBContext>
	{
		public AplicationDBContext CreateDbContext(string[] args)
		{
			// مسیر لایه Presentation (جایی که appsettings.json هست)
			var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Presentation");

			var configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

			var connectionString = configuration.GetConnectionString("SqlConnection");

			var optionsBuilder = new DbContextOptionsBuilder<AplicationDBContext>();
			optionsBuilder.UseSqlServer(connectionString);
			var context = new AplicationDBContext(optionsBuilder.Options);
	
			return context;
		}
	}
}
