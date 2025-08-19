using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Interface
{
	public interface IApplicationDBContext: IDbContext
	{
		

		// Set method
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		DbSet<User> Users { get; set; }
		DbSet<UserRole> UserRols { get; set; }
		DbSet<Role> Rols { get; set; }
		DbSet<RolePermission> RolePermissions { get; set; }
		DbSet<Permission> Permissions { get; set; }

	}
}
