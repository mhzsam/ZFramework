using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Base
{
	public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
	{

		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(s => s.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
			builder.Property(p => p.InsertBy).IsRequired().HasDefaultValue(0);
			builder.Property(p => p.InsertDate).IsRequired().HasDefaultValue(DateTime.Now);
			builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
		}
	}
}
