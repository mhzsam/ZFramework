using Domain.Common;
using Domain.Entites.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entites.Config
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.FirstName).HasMaxLength(64).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(64).IsRequired();
            builder.Property(p => p.MobileNumber).IsRequired();
            builder.Property(p => p.EmailAddress).HasMaxLength(64).IsRequired();
            builder.Property(p => p.ForceChanePassword).IsRequired().HasDefaultValue(false);
           
        }
    }
}
