using Application.DTO.Role;
using Application.DTO.User;
using Application.DTO.UserRole;
using Application.Service.Base;
using Application.Service.RoleService;
using Application.Service.UserRoleService;
using Application.Service.UserService;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2010.Excel;
using Domain.Entites;
using Domain.Exception;
using Domain.Helper;
using Domain.Shared.Interface;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using Mapster;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.AdminApplicationService
{
	public class AdminApplicationService : BaseApplicationService, IAdminApplicationService
	{
		private readonly IUserService _userService;
		private readonly IRoleService _roleService;
		private readonly IUserRoleService _userRoleService;
		public AdminApplicationService(IApplicationDBContext applicationDBContext, ICurrentUserService currentUser, IUserService userService, IRoleService roleService, IUserRoleService userRoleService) : base(applicationDBContext, currentUser)
		{
			_userService = userService;
			_roleService = roleService;
			_userRoleService = userRoleService;
		}


		public async Task<ResponseModel<List<UserDto>>> GetAllUserAsync()
		{
			List<User> lstUser = await _userService.GetAllAsync();
			if (lstUser == null)
				return ResponseModel<List<UserDto>>.Success();

			List<UserDto> result = lstUser.Adapt<List<UserDto>>();
			return ResponseModel<List<UserDto>>.Success(result);
		}
		public async Task<PagingResponseModel<UserDto>> GetPagedActiveUserAsync(QueryParameters queryParameters)
		{
			PagingResponseModel<User>? pagUser = await _userService.GetPagedAsync(queryParameters, o => o.Where(w => w.IsActive == true && w.IsDeleted == false).Include(i => i.UserRoles).ThenInclude(t => t.Role));
			if (pagUser == null)
				return PagingResponseModel<UserDto>.Success();
			var res = pagUser.MapTo<User, UserDto>();
			return res;
		}
		public async Task<ResponseModel<List<RoleDto>>> GetAllActiveRoleAsync(string? searchTitle)
		{
			IEnumerable<Role> enRole;

			if (string.IsNullOrEmpty(searchTitle))
				enRole = await _roleService.GetAllAsync();
			else
				enRole = await _roleService.FindAsync(f => f.RoleName.Contains(searchTitle)); // بهتره Contains باشه برای جستجوی جزئی

			var lstRoleDto = enRole.Adapt<List<RoleDto>>();

			return ResponseModel<List<RoleDto>>.Success(lstRoleDto);

		}
		public async Task<ResponseModel<RoleDto>> AddOrUpdateRoleAsync(RoleDto roleDto)
		{

			return await _roleService.AddOrUpdateRoleAsync(roleDto);
		}
		public async Task<ResponseModel<GetUserRoleForModifyDto>> GetUserRoleForModifyAsync(string _userId)
		{
			int? userId = HashIdHelper.DecodeInt(_userId);
			if (userId == null)
				return ResponseModel<GetUserRoleForModifyDto>.Fail(ErrorText.General.NotFound);

			User? user = (await _userService.FindAsync(w => w.Id == userId && w.IsDeleted == false && w.IsActive == true,
				x => x.Include(i => i.UserRoles.Where(w => w.IsDeleted == false))
					  .ThenInclude(t => t.Role))).FirstOrDefault();

			if (user == null)
				return ResponseModel<GetUserRoleForModifyDto>.Fail(ErrorText.General.NotFound);

			GetUserRoleForModifyDto result = new();
			result.User = user.Adapt<UserDto>();
			if (user?.UserRoles.Count > 0)
				result.AssignedRoles = user.UserRoles.Where(w => w.Role.IsDeleted == false && w.Role.IsActive == true)?.Select(s => s.Role.Adapt<RoleDto>())?.ToList();

			List<Domain.Entites.Role> lstRole = await _roleService.FindAsync(w => w.IsActive == true && w.IsDeleted == false);
			if (lstRole.Count > 0)
			{
				IEnumerable<int> assignedIds = result.AssignedRoles?.Select(r => r.Id) ?? Enumerable.Empty<int>();
				result.AvailableRoles = lstRole.Adapt<List<RoleDto>>().Where(w => !assignedIds.Contains(w.Id)).ToList();
			}

			return ResponseModel<GetUserRoleForModifyDto>.Success(result);
		}
		public async Task<ResponseModel> AddOrUpdateUserRoleAsync(AddOrUpdateUserRoleDto addOrUpdateUserRoleDto)
		{
			try
			{

				int? userId = HashIdHelper.DecodeInt(addOrUpdateUserRoleDto.UserId);
				if (userId == null)
					return ResponseModel.Fail(ErrorText.General.NotFound);

				User? user = await _userService.GetByIdAsync(userId);
				if (user is not User)
					return ResponseModel.Fail(ErrorText.General.NotFound);

				Role role = await _roleService.GetByIdAsync(addOrUpdateUserRoleDto.RoleId);
				if (role is not Role || role.Id < 0)
					return ResponseModel.Fail(ErrorText.General.NotFound);

				List<UserRole> lstUserRole = await _userRoleService.FindAsync(w => w.RoleId == addOrUpdateUserRoleDto.RoleId && w.UserId == userId && w.IsDeleted == false);

				await BeginTransactionAsync();
				if (lstUserRole is not null && lstUserRole.Count > 0)
				{
					foreach (var item in lstUserRole)
					{
						item.IsDeleted = true;
						item.UpdateDate = DateTime.Now;
						item.UpdateBy = _currentUser.UserId ?? throw new CustomException(ErrorText.Auth.Unauthorized);
						await _userRoleService.UpdateAsync(item);
					}
				}
				else
				{
					// اگر موجود نبود، ایجاد کن
					var newUserRole = new UserRole
					{
						UserId = user.Id,
						RoleId = role.Id,
						InsertDate = DateTime.Now,
						InsertBy = _currentUser.UserId ?? throw new CustomException(ErrorText.Auth.Unauthorized),
						IsDeleted = false,
					};
					await _userRoleService.AddAsync(newUserRole);
				}
				await CommitTransactionAsync();
				return ResponseModel.Success();
			}
			catch (Exception ex)
			{
				await RollbackTransactionAsync();
				throw new CustomException(ErrorText.System.UnexpectedError, ex.Message);
			}

		}

	}
}
