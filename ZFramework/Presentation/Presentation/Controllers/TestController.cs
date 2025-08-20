using Domain1.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation1.Controllers
{
	[Authorize]
	public class TestController : BaseController
	{


		[HttpGet]
		public async Task<ResponseModel> GetAll(int PageNumber, int pageSize)
		{


			return ResponseModel.Success();
		}
	}
}
