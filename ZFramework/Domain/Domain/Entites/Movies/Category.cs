using Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Service.MoviesService.MoviesEnums;

namespace Domain.Entites.Movies
{
    public class Category : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public CategoryStatus Status { get; set; }
        public string Description { get; set; }
        public int Priorty { get; set; }
    }
}
