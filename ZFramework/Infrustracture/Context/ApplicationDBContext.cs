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


			modelBuilder.Entity<User>().HasData(
				new User() { Id = 1, FirstName = "Mohammad", LastName = "Zarrabi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user1@test.com", MobileNumber = "09120198177" },
				new User() { Id = 2, FirstName = "Ali", LastName = "Rezaei", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user2@test.com", MobileNumber = "09120000002" },
				new User() { Id = 3, FirstName = "Sara", LastName = "Ahmadi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user3@test.com", MobileNumber = "09120000003" },
				new User() { Id = 4, FirstName = "Hossein", LastName = "Karimi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user4@test.com", MobileNumber = "09120000004" },
				new User() { Id = 5, FirstName = "Mina", LastName = "Rahimi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user5@test.com", MobileNumber = "09120000005" },
				new User() { Id = 6, FirstName = "Reza", LastName = "Akbari", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user6@test.com", MobileNumber = "09120000006" },
				new User() { Id = 7, FirstName = "Neda", LastName = "Moradi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user7@test.com", MobileNumber = "09120000007" },
				new User() { Id = 8, FirstName = "Hamed", LastName = "Kazemi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user8@test.com", MobileNumber = "09120000008" },
				new User() { Id = 9, FirstName = "Maryam", LastName = "Shahbazi", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user9@test.com", MobileNumber = "09120000009" },
				new User() { Id = 10, FirstName = "Farid", LastName = "Taheri", Password = SecurityHelper.PasswordToSHA256("1234"), EmailAddress = "user10@test.com", MobileNumber = "09120000010" }
);
			modelBuilder.Entity<Role>().HasData(
				new Role() { Id = 1, IsActive = true, RoleName = "SuperAdmin" },
				new Role() { Id = 2, IsActive = true, RoleName = "Admin" },
				new Role() { Id = 3, IsActive = true, RoleName = "Manager" },
				new Role() { Id = 4, IsActive = true, RoleName = "User" }
);
			modelBuilder.Entity<UserRole>().HasData(
				new UserRole() { Id = 1, UserId = 1, RoleId = 1 }, // Mohammad → SuperAdmin
				new UserRole() { Id = 2, UserId = 2, RoleId = 2 }, // Ali → Admin
				new UserRole() { Id = 3, UserId = 3, RoleId = 4 }, // Sara → User
				new UserRole() { Id = 4, UserId = 4, RoleId = 3 }, // Hossein → Manager
				new UserRole() { Id = 5, UserId = 5, RoleId = 4 }, // Mina → User
				new UserRole() { Id = 6, UserId = 6, RoleId = 2 }, // Reza → Admin
				new UserRole() { Id = 7, UserId = 7, RoleId = 4 }, // Neda → User
				new UserRole() { Id = 8, UserId = 8, RoleId = 3 }, // Hamed → Manager
				new UserRole() { Id = 9, UserId = 9, RoleId = 4 }, // Maryam → User
				new UserRole() { Id = 10, UserId = 10, RoleId = 2 } // Farid → Admin
);

		}
		#endregion


	}
}
