using Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Service.MoviesService.MoviesEnums;

namespace Domain.Entites.Movies
{
    public class Movie : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public MovieStatus Status { get; set; }
        public int CategoryCode { get; set; }   
        public string Descriptions { get; set; }


    }
}
