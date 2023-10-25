using Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public interface IBaseEntity
    {        
       
        bool IsDeleted { get; set; }
        DateTime? DeletedDate { get; set; }   
        DateTime InsertDate { get; set; }
        int InsertBy { get; set; }
        DateTime? UpdateDate { get; set; }
        int? UpdateBy { get; set; }

    }
}
