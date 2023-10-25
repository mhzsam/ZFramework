using Domain.Entites.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Config
{
    public class UserRoleConfiguration: BaseConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.RoleId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();     
        }
    }
}
