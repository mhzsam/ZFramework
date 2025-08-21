using Domain.Entites.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
	public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
	{

		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{

			builder.Property(p => p.InsertBy).IsRequired();
			builder.Property(p => p.InsertBy).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);


			builder.Property(p => p.InsertDate).IsRequired().HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
			builder.Property(p => p.InsertDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

			builder.Property(p => p.UpdateDate).HasDefaultValue(null).ValueGeneratedNever();
			builder.Property(p => p.UpdateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
			builder.Property(p => p.UpdateDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

			builder.Property(p => p.UpdateBy).HasDefaultValue(null).ValueGeneratedNever();
			builder.Property(p => p.UpdateBy).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
			builder.Property(p => p.UpdateBy).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

			builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
		}
	}
}
