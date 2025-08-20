using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Message
{
	public static class ErrorText
	{
		#region Authentication & Authorization
		public static class Auth
		{
			public const string Unauthorized = "شما احراز هویت نشده‌اید یا دسترسی لازم به این بخش را ندارید";
			public const string InvalidCredentials = "نام کاربری یا رمز عبور اشتباه است";
			public const string AccountLocked = "حساب کاربری شما به دلیل تلاش‌های ناموفق متعدد قفل شده است";
			public const string AccountDisabled = "حساب کاربری شما غیرفعال است";
			public const string TokenExpired = "توکن احراز هویت منقضی شده است";
			public const string InvalidToken = "توکن احراز هویت نامعتبر است";
			public const string RefreshTokenExpired = "توکن تازه‌سازی منقضی شده است";
			public const string PermissionDenied = "شما دسترسی لازم برای انجام این عملیات را ندارید";
			public const string RequireLogin = "برای ادامه باید وارد حساب کاربری خود شوید";
			public const string SessionExpired = "جلسه کاری شما منقضی شده است";
			public const string TwoFactorRequired = "احراز هویت دو مرحله‌ای الزامی است";
			public const string InvalidTwoFactorCode = "کد احراز هویت دو مرحله‌ای نامعتبر است";
			public const string ConfigNotfound = "تنظیمات توکن پیدا نشد";
		}
		#endregion



		#region Validation
		public static class Validation
		{
			public const string Required = "این فیلد الزامی است";
			public const string InvalidFormat = "فرمت وارد شده صحیح نیست";
			public const string TooShort = "مقدار وارد شده کوتاه‌تر از حد مجاز است";
			public const string TooLong = "مقدار وارد شده طولانی‌تر از حد مجاز است";
			public const string InvalidRange = "مقدار وارد شده خارج از بازه مجاز است";
			public const string InvalidDate = "تاریخ وارد شده صحیح نیست";
			public const string FutureDate = "تاریخ نمی‌تواند در آینده باشد";
			public const string PastDate = "تاریخ نمی‌تواند در گذشته باشد";
			public const string InvalidNumber = "عدد وارد شده صحیح نیست";
			public const string NegativeNumber = "عدد نمی‌تواند منفی باشد";
			public const string InvalidFileFormat = "فرمت فایل مجاز نیست";
			public const string FileSizeExceeded = "حجم فایل بیش از حد مجاز است";
		}
		#endregion

		#region Database
		public static class Database
		{
			public const string ConnectionFailed = "خطا در اتصال به پایگاه داده";
			public const string SaveFailed = "خطا در ذخیره اطلاعات";
			public const string DeleteFailed = "خطا در حذف اطلاعات";
			public const string UpdateFailed = "خطا در به‌روزرسانی اطلاعات";
			public const string DuplicateEntry = "رکورد تکراری وجود دارد";
			public const string ForeignKeyConstraint = "امکان حذف به دلیل وابستگی با سایر رکوردها وجود ندارد";
			public const string ConcurrencyConflict = "اطلاعات توسط کاربر دیگری تغییر یافته است";
			public const string TransactionFailed = "خطا در انجام تراکنش";
			public const string MigrationFailed = "خطا در اجرای مایگریشن";
		}
		#endregion

		#region File Management
		public static class File
		{
			public const string NotFound = "فایل مورد نظر یافت نشد";
			public const string UploadFailed = "خطا در آپلود فایل";
			public const string DeleteFailed = "خطا در حذف فایل";
			public const string InvalidFormat = "فرمت فایل مجاز نیست";
			public const string SizeExceeded = "حجم فایل بیش از حد مجاز است";
			public const string AccessDenied = "دسترسی به فایل امکان‌پذیر نیست";
			public const string CorruptedFile = "فایل آسیب دیده است";
			public const string StorageFull = "فضای ذخیره‌سازی پر است";
		}
		#endregion

		#region Network & API
		public static class Network
		{
			public const string ConnectionTimeout = "زمان اتصال به سرور به پایان رسید";
			public const string ServiceUnavailable = "سرویس در حال حاضر در دسترس نیست";
			public const string BadRequest = "درخواست نامعتبر است";
			public const string InternalServerError = "خطای داخلی سرور";
			public const string RateLimitExceeded = "تعداد درخواست‌ها بیش از حد مجاز است";
			public const string MaintenanceMode = "سیستم در حال تعمیر است";
			public const string ApiKeyInvalid = "کلید API نامعتبر است";
		}
		#endregion

		#region Business Logic
		public static class Business
		{
			public const string InsufficientBalance = "موجودی کافی نیست";
			public const string OrderNotFound = "سفارش یافت نشد";
			public const string OrderCancelled = "سفارش لغو شده است";
			public const string OrderCompleted = "سفارش تکمیل شده و قابل تغییر نیست";
			public const string ProductOutOfStock = "محصول موجود نیست";
			public const string InvalidOperation = "عملیات نامعتبر است";
			public const string BusinessRuleViolation = "قوانین کسب و کار نقض شده است";
			public const string WorkflowError = "خطا در فرآیند کاری";
		}
		#endregion

		#region System
		public static class System
		{
			public const string UnexpectedError = "خطای غیرمنتظره‌ای رخ داده است";
			public const string MaintenanceRequired = "سیستم نیاز به تعمیر دارد";
			public const string FeatureNotAvailable = "این قابلیت در حال حاضر در دسترس نیست";
			public const string ConfigurationError = "خطا در تنظیمات سیستم";
			public const string LicenseExpired = "مجوز استفاده منقضی شده است";
			public const string ResourceNotFound = "منبع مورد نظر یافت نشد";
			public const string MemoryLimitExceeded = "حد مجاز حافظه اشغال شده است";
		}
		#endregion


		#region Email & SMS
		public static class Communication
		{
			public const string EmailSendFailed = "ارسال ایمیل ناموفق بود";
			public const string SmsSendFailed = "ارسال پیامک ناموفق بود";
			public const string InvalidEmailTemplate = "قالب ایمیل نامعتبر است";
			public const string InvalidSmsTemplate = "قالب پیامک نامعتبر است";
			public const string RecipientNotFound = "گیرنده یافت نشد";
			public const string MessageTooLong = "پیام بیش از حد مجاز طولانی است";
		}
		#endregion

		#region Security
		public static class Security
		{
			public const string SuspiciousActivity = "فعالیت مشکوک شناسایی شد";
			public const string TooManyAttempts = "تعداد تلاش‌های ناموفق بیش از حد مجاز";
			public const string IpBlocked = "آدرس IP شما مسدود شده است";
			public const string CsrfTokenMissing = "توکن امنیتی موجود نیست";
			public const string InvalidCsrfToken = "توکن امنیتی نامعتبر است";
			public const string EncryptionFailed = "خطا در رمزگذاری";
			public const string DecryptionFailed = "خطا در رمزگشایی";
		}
		#endregion

		#region Cache & Performance
		public static class Cache
		{
			public const string CacheConnectionFailed = "خطا در اتصال به کش";
			public const string CacheWriteFailed = "خطا در نوشتن کش";
			public const string CacheReadFailed = "خطا در خواندن کش";
			public const string CacheExpired = "کش منقضی شده است";
		}
		#endregion

		#region General
		public static class General
		{
			public const string Success = "عملیات با موفقیت انجام شد";
			public const string Failed = "عملیات ناموفق بود";
			public const string Processing = "در حال پردازش...";
			public const string NotImplemented = "این قابلیت هنوز پیاده‌سازی نشده است";
			public const string Timeout = "زمان انتظار به پایان رسید";
			public const string Cancelled = "عملیات لغو شد";
			public const string InvalidRequest = "درخواست نامعتبر";
			public const string NotFound = " هیچ موردی یافت نشد";

		}
		#endregion
	}
}
