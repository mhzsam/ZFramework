using Application1.DTO.UserDto;
using Application1.Service.Base;
using Domain1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Service.UserService
{
	public interface IUserService : IBaseService<User>
	{

		public Task<(bool result, string token)> Login(string Email, string PassWord);
		Task<User> SingUp(AddUserModel addUserModel);


	}
}
