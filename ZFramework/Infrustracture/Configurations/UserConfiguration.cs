using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
	public class UserConfiguration : BaseConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);
			builder.HasKey(s => s.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
			builder.Property(p => p.FirstName).HasMaxLength(64).IsRequired();
			builder.Property(p => p.LastName).HasMaxLength(64).IsRequired();
			builder.Property(p => p.MobileNumber).IsRequired();
			builder.Property(p => p.EmailAddress).HasMaxLength(64).IsRequired();
			builder.Property(p => p.ForceChanePassword).IsRequired().HasDefaultValue(false);

		}
	}
}
