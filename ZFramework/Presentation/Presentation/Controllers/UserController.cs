using Application.DTO.ResponseModel;
using Application.DTO.UserService;
using Application.Helper;
using Application.Interface;
using Application.Service.ResponseService;
using Application.Service.UserService;
using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class UserController : BaseController
    {
        
        private readonly IUserService _userService;


        public UserController(IResponseService responseService, IUserService userService) : base(responseService)
        {
           
            _userService = userService;
        }

        [HttpGet]
        public async Task<RessponseModel> GetAll(int PageNumber, int pageSize)
        {
           var model= await _userService.GetAll(PageNumber, pageSize);
           
            return responseGenerator.SuccssedWithResult(model);
        }

        [HttpPost]
        public async Task<RessponseModel>SingUp(AddUserModel addUserModel)
        {
            var model = await _userService.SingUp(addUserModel);
            return responseGenerator.SuccssedWithResult(model);
        }
        [HttpPost]
        public async Task<RessponseModel> Login(string email,string password)
        {
            var model = await _userService.Login(email, password);
            if (!model.result)
            {
             return   responseGenerator.Fail(System.Net.HttpStatusCode.NotFound, ErrorText.NotFoundUser);
            }
            return responseGenerator.SuccssedWithResult($"Bearer {model.token}");
        }
    }
}
