using Application.DTO.UserDto;
using Application.Service.Base;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.UserService
{
    public interface IUserService:IBaseService<User>
    {
     
        public Task<(bool result,string token)> Login(string Email, string PassWord);
        Task<User> SingUp(AddUserModel addUserModel);


    }
}
