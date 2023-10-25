using Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class UserRole : BaseEntity
    {

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }

    }
}
