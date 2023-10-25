using Application.DTO.ResponseModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Service.MoviesService.MoviesEnums;

namespace Application.Service.MoviesService
{
    public interface IMoviesService
    {
        Task<RessponseModel> AddOrUpdateByExcelFile(IFormFile file, ExcelFileType type);
        Task<RessponseModel> GetTopCategoryWithMOvies();

    }

}
