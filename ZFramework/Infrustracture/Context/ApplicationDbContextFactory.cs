using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
	{
		public ApplicationDBContext CreateDbContext(string[] args)
		{
			// مسیر لایه Presentation (جایی که appsettings.json هست)
			var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Presentation");

			var configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

			var connectionString = configuration.GetConnectionString("SqlConnection");

			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
			optionsBuilder.UseSqlServer(connectionString);
			var context = new ApplicationDBContext(optionsBuilder.Options);
	
			return context;
		}
	}
}
