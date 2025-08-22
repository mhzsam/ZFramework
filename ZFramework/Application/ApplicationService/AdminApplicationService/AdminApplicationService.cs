using Application.DTO.User;
using Application.Service.Base;
using Application.Service.UserService;
using Domain.Entites;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using Mapster;
using Microsoft.EntityFrameworkCore;
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


		public async Task<ResponseModel<List<UserDto>>> GetAllUserAsync()
		{
			List<User> lstUser = await _userService.GetAllAsync();
			if (lstUser == null)
				return ResponseModel<List<UserDto>>.Success();

			List<UserDto> result = lstUser.Adapt<List<UserDto>>();
			return ResponseModel<List<UserDto>>.Success(result);
		}
		public async Task<PagingResponseModel<UserDto>> GetPagedUserAsync(QueryParameters queryParameters)
		{
			PagingResponseModel<User>? pagUser = await _userService.GetPagedAsync(queryParameters, o => o.Include(i => i.UserRoles).ThenInclude(t => t.Role));
			if (pagUser == null)
				return PagingResponseModel<UserDto>.Success();
			var res = pagUser.MapTo<User, UserDto>();
			return res;
		}
	}
}
