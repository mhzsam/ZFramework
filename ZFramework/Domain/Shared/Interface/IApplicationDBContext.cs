using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Domain.Shared.Interface
{
	public interface IApplicationDBContext : IDbContext
	{


		// Set method
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		DbSet<User> Users { get; set; }
		//DbSet<UserRole> UserRols { get; set; }
		//DbSet<Role> Rols { get; set; }
		//DbSet<RolePermission> RolePermissions { get; set; }
		//DbSet<Permission> Permissions { get; set; }

	}
}
