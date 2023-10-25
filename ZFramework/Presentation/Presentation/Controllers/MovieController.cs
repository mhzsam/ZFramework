using Application.DTO.ResponseModel;
using Application.Service.MoviesService;
using Application.Service.ResponseService;
using Application.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    [AllowAnonymous]
    public class MovieController : BaseController
    {

        private readonly IMoviesService _moviesService;

        public MovieController(IResponseService responseService, IMoviesService moviesService) : base(responseService)
        {
            _moviesService = moviesService;
        }
        [SwaggerOperation(Summary = "فیلم=1 و ژانر=2 در ریسپانس زمان انجام بر می گردد ")]     
        [HttpPost]
        public async Task<RessponseModel> AddOrUpdateExcelFile(IFormFile file, MoviesEnums.ExcelFileType type)
        {
            return await _moviesService.AddOrUpdateByExcelFile(file, type);
           
        }
        [HttpGet]
        public async Task<RessponseModel> GetTopCategoryWithMOvies()
        {

            return await _moviesService.GetTopCategoryWithMOvies();

        }
    }
}
