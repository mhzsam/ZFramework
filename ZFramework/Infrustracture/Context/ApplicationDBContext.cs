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
			//modelBuilder.SeedData();




		}

		#endregion

	}
	public static class ModelBuilderExtensions
	{
		public static void SeedData(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User() { Id = 1, FirstName = "Mohammad", LastName = "Zarrabi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user1@test.com", MobileNumber = "09120198177" },
				new User() { Id = 2, FirstName = "Ali", LastName = "Rezaei", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user2@test.com", MobileNumber = "09120000002" },
				new User() { Id = 3, FirstName = "Sara", LastName = "Ahmadi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user3@test.com", MobileNumber = "09120000003" }
			
			);

			modelBuilder.Entity<Role>().HasData(
				new Role() { Id = -1, IsActive = true, RoleName = "SuperAdmin" },
				new Role() { Id = 1, IsActive = true, RoleName = "Admin" },
				new Role() { Id = 2, IsActive = true, RoleName = "Manager" },
				new Role() { Id = 3, IsActive = true, RoleName = "User" }
			);

			modelBuilder.Entity<UserRole>().HasData(
				new UserRole() { Id = 1, UserId = 1, RoleId = -1 },
				new UserRole() { Id = 2, UserId = 1, RoleId = 1 },
				new UserRole() { Id = 3, UserId = 2, RoleId = 2 }
			
			);
		}
	}
}
