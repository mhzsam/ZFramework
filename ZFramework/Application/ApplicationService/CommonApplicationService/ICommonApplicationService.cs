using Application.DTO.UserDto;
using Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.CommonApplicationService
{
	public interface ICommonApplicationService
	{
		Task<ResponseModel<string>> Login(string mobileNumber, string password);
		Task<ResponseModel<GetUserDto>> SingUp(AddUserModel addUserModel);
	}
}
