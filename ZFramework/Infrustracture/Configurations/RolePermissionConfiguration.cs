using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
	public class RolePermissionConfiguration : BaseConfiguration<RolePermission>
	{

		public void Configure(EntityTypeBuilder<RolePermission> builder)
		{
			base.Configure(builder);
			builder.HasKey(s => s.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
			builder.Property(p => p.RoleId).IsRequired();
			builder.Property(p => p.PermissionId).IsRequired();

			builder.HasOne(rp => rp.Role)
				   .WithMany()
				   .HasForeignKey(rp => rp.RoleId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(rp => rp.Permission)
				   .WithMany()
				   .HasForeignKey(rp => rp.PermissionId)
				   .OnDelete(DeleteBehavior.Cascade);

		}

	}
}
