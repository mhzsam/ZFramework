using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Message
{
	public static class ControllerDescription
	{
		public static class Common
		{
			public const string GetCaptcha = "گرفتن کپچا";
			public const string ValidateCaptcha = "بررسی کپچا";
			public const string ValidateCaptcha2 = "بررسی کپچا نسخه ۲";
			
			public const string SignUp = "ایجاد حساب کاربری";
			public const string Login = "ورود کاربر";

		}

		public static class Test
		{
			public const string GetAll = "تست گرفتن همه موارد";
		}

		public static class User
		{
			public const string GetAll = "گرفتن کل کاربران";
		}
	}
}
