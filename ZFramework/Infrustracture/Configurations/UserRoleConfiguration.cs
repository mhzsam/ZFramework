using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
	public class UserRoleConfiguration : BaseConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			base.Configure(builder);
			builder.HasKey(s => s.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
			builder.Property(p => p.RoleId).IsRequired();
			builder.Property(p => p.UserId).IsRequired();

			builder.HasOne<User>()
				   .WithMany(u => u.UserRoles)
				   .HasForeignKey(ur => ur.UserId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<Role>()
				   .WithMany()
				   .HasForeignKey(ur => ur.RoleId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}

}
