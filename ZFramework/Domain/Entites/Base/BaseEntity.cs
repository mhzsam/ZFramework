using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Base
{
	public class BaseEntity : IBaseEntity
	{

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }


		public DateTime InsertDate
		{
			get
			{
				return DateTime.Now;
			}
			set { }
		}


		public int InsertBy { get; set; }

		public DateTime? UpdateDate { get; set; }

		public int? UpdateBy { get; set; }
	}
}
