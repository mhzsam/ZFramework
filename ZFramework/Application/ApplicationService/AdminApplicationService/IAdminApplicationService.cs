using Application.DTO.UserDto;
using Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.AdminApplicationService
{
	public interface IAdminApplicationService
	{
		Task<ResponseModel<List<GetUserDto>>> GetAllUserAsync();
	}
}
