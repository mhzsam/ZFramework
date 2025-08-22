using Application.DTO.User;
using Application.Helper;
using Application.Service.Base;
using Application.Service.UserService;
using Domain.Helper;
using Domain.Shared.Interface;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Mapster;

namespace Application.ApplicationService.CommonApplicationService
{

	public class CommonApplicationService : BaseApplicationService, ICommonApplicationService
	{
		private readonly IUserService _userService;

		public CommonApplicationService(IApplicationDBContext applicationDBContext, ICurrentUserService currentUserService, IUserService userService) : base(applicationDBContext, currentUserService)
		{
			_userService = userService;
		}
		public async Task<ResponseModel<string>> Login(string mobileNumber, string password)
		{
			var result = await _userService.LoginAsync(mobileNumber, password);
			if (!result.result)
				return ResponseModel<string>.Fail(ErrorText.Auth.InvalidCredentials);

			return ResponseModel<string>.Success(result.token);

		}

		public async Task<ResponseModel<UserDto>> SingUp(AddUserModel addUserModel)
		{
			var result = await _userService.SingUp(addUserModel);
			if (result == null)
				ResponseModel<UserDto>.Fail(ErrorText.System.UnexpectedError);

			UserDto getUserDto = result?.Adapt<UserDto>();

			return ResponseModel<UserDto>.Success(getUserDto);

		}
	}
}
