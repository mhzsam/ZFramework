using Application.DTO.UserDto;
using Application.Service.Base;
using Domain.Entites;

namespace Application.Service.UserService
{
	public interface IUserService : IBaseService<User>
	{

		public Task<(bool result, string token)> Login(string Email, string PassWord);
		Task<User> SingUp(AddUserModel addUserModel);


	}
}
