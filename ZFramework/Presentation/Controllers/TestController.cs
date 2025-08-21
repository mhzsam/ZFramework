using Domain.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Presentation.Controllers
{
	[Authorize]
	public class TestController : BaseController
	{


		[HttpGet]
		[Description("تست")]
		public async Task<ResponseModel> GetAll(int PageNumber, int pageSize)
		{


			return ResponseModel.Success();
		}
	}
}
