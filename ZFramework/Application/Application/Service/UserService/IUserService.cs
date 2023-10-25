using Application.DTO.UserService;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll( int PageNumber, int pageSize);
        Task<User> GetById(int id);
        public Task<(bool result,string token)> Login(string Email, string PassWord);
        Task<User> SingUp(AddUserModel addUserModel);


    }
}
