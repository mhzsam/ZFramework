using Application1.DTO.UserDto;
using Application1.Helper;
using Application1.Service.Base;
using DocumentFormat.OpenXml.InkML;
using Domain.Common;
using Domain1.Entites;
using Domain1.Helper;
using Domain1.Shared.Interface;
using Domain1.Shared.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Application1.Service.UserService
{
	public class UserService : BaseService<User>, IUserService
	{
		private readonly JwtConfig _jwtConfig;

		public UserService(IApplicationDBContext applicationDBContext, IOptions<AppSettings> appSettings) : base(applicationDBContext)
		{
			_jwtConfig = appSettings.Value.JWTConfig;

		}

		public async Task<(bool result, string token)> Login(string Email, string PassWord)
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
			var token = SecurityHelper.GetNewToken(user.Id, _jwtConfig.TokenKey, _jwtConfig.TokenTimeOut);
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
