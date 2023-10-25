using Application.DTO.Movie;
using Domain.Entites.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IMovieRepository
    {
        Task<List<CategoryMovieModel>> GetTopCategoryWithMOvies();
    }
}
