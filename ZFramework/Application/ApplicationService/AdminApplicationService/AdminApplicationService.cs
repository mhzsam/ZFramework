using Application.DTO.UserDto;
using Application.Service.Base;
using Application.Service.UserService;
using Domain.Entites;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.AdminApplicationService
{
	public class AdminApplicationService : BaseApplicationService, IAdminApplicationService
	{
		private readonly IUserService _userService;
		public AdminApplicationService(IApplicationDBContext applicationDBContext, ICurrentUserService currentUser, IUserService userService) : base(applicationDBContext, currentUser)
		{
			_userService = userService;
		}


		public async Task<ResponseModel<List<GetUserDto>>> GetAllUserAsync()
		{
			List<User> lstUser = await _userService.GetAllAsync();
			if (lstUser == null)
				return ResponseModel<List<GetUserDto>>.Success(default);

			List<GetUserDto> result = lstUser.Adapt<List<GetUserDto>>();
			return ResponseModel<List<GetUserDto>>.Success(result);
		}
	}
}
