using Application.DTO.User;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.AdminApplicationService
{
	public interface IAdminApplicationService
	{
		Task<ResponseModel<List<UserDto>>> GetAllUserAsync();
		Task<PagingResponseModel<UserDto>> GetPagedUserAsync(QueryParameters queryParameters);
	}
}
