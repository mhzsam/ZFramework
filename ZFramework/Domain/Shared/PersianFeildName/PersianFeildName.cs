using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.PersianFeildName
{
	public static class PersianFeildName
	{
		public static class Role
		{
			public const string Id = "شناسه نقش";
			public const string RoleName = "نام نقش";
			public const string IsActive = "فعال بودن نقش";
			public const string RolePermissions = "مجوزهای نقش";
		}

		public static class Permission
		{
			public const string Id = "شناسه دسترسی";
			public const string ProjectName = "نام پروژه";
			public const string ControllerName = "نام کنترلر";
			public const string ActionName = "نام اکشن";
			public const string ActionMethod = "نوع متد";
			public const string PermissionHash = "هش دسترسی";
			public const string Description = "توضیحات دسترسی";
			public const string IsActive = "فعال بودن دسترسی";
		}

		public static class RolePermission
		{
			public const string Id = "شناسه نقش-دسترسی";
			public const string RoleId = "شناسه نقش";
			public const string Role = "نقش";
			public const string PermissionId = "شناسه دسترسی";
			public const string Permission = "دسترسی";
		}

		public static class User
		{
			public const string Id = "شناسه کاربر";
			public const string FirstName = "نام";
			public const string LastName = "نام خانوادگی";
			public const string MobileNumber = "شماره موبایل";
			public const string NationalCode = "کد ملی";
			public const string PhoneNumber = "شماره تلفن";
			public const string Avatar = "تصویر پروفایل";
			public const string EmailAddress = "آدرس ایمیل";
			public const string Password = "رمز عبور";
			public const string LastLoginDate = "تاریخ آخرین ورود";
			public const string ForceChangePassword = "اجبار تغییر رمز";
			public const string Token = "توکن کاربر";
			public const string IsActive = "فعال بودن کاربر";
			public const string UserRoles = "نقش‌های کاربر";
		}

		public static class UserRole
		{
			public const string Id = "شناسه نقش-کاربر";
			public const string RoleId = "شناسه نقش";
			public const string Role = "نقش";
			public const string UserId = "شناسه کاربر";
			public const string User = "کاربر";
		}
	}
}

