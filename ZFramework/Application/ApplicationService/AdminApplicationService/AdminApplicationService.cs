using Application.Service.Base;
using Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.AdminApplicationService
{
	public class AdminApplicationService : BaseApplicationService, IAdminApplicationService
	{
		public AdminApplicationService(IApplicationDBContext applicationDBContext, ICurrentUserService currentUser) : base(applicationDBContext, currentUser)
		{
		}
	}
}
