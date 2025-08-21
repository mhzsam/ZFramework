using Application.DTO.UserDto;
using Application.Helper;
using Application.Service.Base;
using Domain.Entites;
using Domain.Helper;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Application.Service.UserService
{
	public class UserService : BaseService<User>, IUserService
	{

		public UserService(IApplicationDBContext applicationDBContext) : base(applicationDBContext)
		{


		}

		public async Task<(bool result, string token)> LoginAsync(string Email, string PassWord)
		{

			var user = await _dbSet.Where(t => t.EmailAddress == Email.Trim()).FirstOrDefaultAsync();
			if (user == null)
			{
				return (false, "");
			}
			PassWord = SecurityHelper.PasswordToSHA256(PassWord.Trim());
			if (PassWord != user.Password)
			{
				return (false, "");
			}
			var token = SecurityHelper.GetNewToken(new TokenClaim(user.Id));
			return (true, token);

		}

		public async Task<User> SingUp(AddUserModel addUserModel)
		{
			addUserModel.Password = SecurityHelper.PasswordToSHA256(addUserModel.Password);

			//var res = addUserModel.Adapt<User>();
			var user = Mapper<User>.ToEntity(addUserModel);
			_dbSet.Add(user);
			await SaveChangesAsync();
			return user;

		}

	}
}
