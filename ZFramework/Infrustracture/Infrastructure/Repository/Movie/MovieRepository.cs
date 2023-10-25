using Application.DTO.Movie;
using Application.Interface;
using Application.Service.MoviesService;
using DocumentFormat.OpenXml.InkML;
using Domain.Context;
using Domain.Entites.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Movie
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDBContext _context;


        public MovieRepository(ApplicationDBContext context)
        {
            
            _context = context;

        }

        public Task<List<CategoryMovieModel>> GetTopCategoryWithMOvies()
        {
           
            var ls = (
                    from c in _context.Categories.Where(s => s.Status == MoviesEnums.CategoryStatus.Active).OrderBy(s => s.Priorty).Select(s =>new { s.Name,s.Code }).Take(6)
                    select new CategoryMovieModel()
                    {
                        Category = c.Name,
                        Movies = _context.Movies.Where(s => s.CategoryCode == c.Code).Where(s => s.Status == MoviesEnums.MovieStatus.Active).OrderByDescending(s=>s.UpdateDate).Take(10).ToList(),

                    }
                    ).Where(s => s.Movies.Count > 0).ToListAsync();

            return ls;

        }
    }
}
