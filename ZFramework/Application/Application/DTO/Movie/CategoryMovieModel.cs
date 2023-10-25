using Domain.Entites.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Movie
{
    public class CategoryMovieModel
    {
        public string Category { get; set; }
        public List<Domain.Entites.Movies.Movie> Movies { get; set; }
    }
}
