using Domain.Entites.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Config
{
    public class RolePermissionConfiguration : BaseConfiguration<RolePermission>
    {
        
            public void Configure(EntityTypeBuilder<RolePermission> builder)
            {
                base.Configure(builder);
                builder.Property(p => p.RoleId).IsRequired();
                builder.Property(p => p.PermissionId).IsRequired();


            }
        
    }
}
