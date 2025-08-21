using Domain.Entites;
using Domain.Helper;
using Domain.Shared.Interface;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
	public class ApplicationDBContext : DbContext, IApplicationDBContext
	{
		public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{
		}
		public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();

		#region DbSet
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRols { get; set; }
		public DbSet<Role> Rols { get; set; }
		public DbSet<RolePermission> RolePermissions { get; set; }
		public DbSet<Permission> Permissions { get; set; }


		#endregion


		#region Config
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
			modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
			
			
			modelBuilder.Entity<User>().HasData(new User() { Id = 1, FirstName = "Mohammad555", LastName = "Zarrabi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "mhzsam@gmail.com", MobileNumber = "09120198177" });
			modelBuilder.Entity<Role>().HasData(new Role() { Id = 1, IsActive = true, RoleName = "SuperAdmin" });
			modelBuilder.Entity<UserRole>().HasData(new UserRole() { Id = 1, RoleId = 1, UserId = 1 });

		}
		#endregion


	}
}
