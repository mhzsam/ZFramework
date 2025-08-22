public static class ValidationMessages
{
	// خطاهای اساسی
	public static string Required(string fieldName) => $"مقدار {fieldName} الزامی است";

	public static string NotEmpty(string fieldName) => $"{fieldName} نمی‌تواند خالی باشد";

	public static string NotNull(string fieldName) => $"{fieldName} نمی‌تواند null باشد";

	// خطاهای مربوط به طول
	public static string MaxLength(string fieldName, int maxLength) =>
		$"حداکثر طول {fieldName} باید {maxLength} کاراکتر باشد";

	public static string MinLength(string fieldName, int minLength) =>
		$"حداقل طول {fieldName} باید {minLength} کاراکتر باشد";

	public static string Length(string fieldName, int minLength, int maxLength) =>
		$"طول {fieldName} باید بین {minLength} تا {maxLength} کاراکتر باشد";

	public static string ExactLength(string fieldName, int length) =>
		$"طول {fieldName} باید دقیقاً {length} کاراکتر باشد";

	// خطاهای عددی
	public static string GreaterThan(string fieldName, object value) =>
		$"{fieldName} باید بزرگتر از {value} باشد";

	public static string GreaterThanOrEqual(string fieldName, object value) =>
		$"{fieldName} باید بزرگتر یا مساوی {value} باشد";

	public static string LessThan(string fieldName, object value) =>
		$"{fieldName} باید کمتر از {value} باشد";

	public static string LessThanOrEqual(string fieldName, object value) =>
		$"{fieldName} باید کمتر یا مساوی {value} باشد";

	public static string Equal(string fieldName, object value) =>
		$"{fieldName} باید برابر {value} باشد";

	public static string NotEqual(string fieldName, object value) =>
		$"{fieldName} نباید برابر {value} باشد";

	public static string Range(string fieldName, object from, object to) =>
		$"{fieldName} باید بین {from} تا {to} باشد";

	// خطاهای Regex و الگو
	public static string Matches(string fieldName, string pattern) =>
		$"{fieldName} با الگوی مورد نظر مطابقت ندارد";

	public static string EmailAddress(string fieldName) =>
		$"{fieldName} فرمت آدرس ایمیل صحیحی ندارد";

	public static string CreditCard(string fieldName) =>
		$"{fieldName} شماره کارت اعتباری معتبری نیست";

	public static string PhoneNumber(string fieldName) =>
		$"{fieldName} فرمت شماره تلفن صحیحی ندارد";

	public static string Url(string fieldName) =>
		$"{fieldName} آدرس وب معتبری نیست";

	// خطاهای مقایسه میدان‌ها
	public static string EqualTo(string fieldName, string comparisonProperty) =>
		$"{fieldName} باید با {comparisonProperty} مطابقت داشته باشد";

	public static string NotEqualTo(string fieldName, string comparisonProperty) =>
		$"{fieldName} نباید با {comparisonProperty} مطابقت داشته باشد";

	// خطاهای تاریخ و زمان
	public static string DateTimeFormat(string fieldName) =>
		$"{fieldName} فرمت تاریخ و زمان صحیحی ندارد";

	public static string FutureDate(string fieldName) =>
		$"{fieldName} باید تاریخی در آینده باشد";

	public static string PastDate(string fieldName) =>
		$"{fieldName} باید تاریخی در گذشته باشد";

	public static string DateRange(string fieldName, DateTime from, DateTime to) =>
		$"{fieldName} باید بین {from:yyyy/MM/dd} تا {to:yyyy/MM/dd} باشد";

	// خطاهای مجموعه (Collection)
	public static string CollectionNotEmpty(string fieldName) =>
		$"{fieldName} نمی‌تواند خالی باشد";

	public static string CollectionMinCount(string fieldName, int minCount) =>
		$"{fieldName} باید حداقل {minCount} آیتم داشته باشد";

	public static string CollectionMaxCount(string fieldName, int maxCount) =>
		$"{fieldName} باید حداکثر {maxCount} آیتم داشته باشد";

	public static string CollectionCountRange(string fieldName, int minCount, int maxCount) =>
		$"تعداد آیتم‌های {fieldName} باید بین {minCount} تا {maxCount} باشد";

	// خطاهای عضویت در مجموعه
	public static string IsInEnum(string fieldName) =>
		$"مقدار {fieldName} معتبر نیست";

	public static string IsIn(string fieldName, string allowedValues) =>
		$"{fieldName} باید یکی از مقادیر مجاز باشد: {allowedValues}";

	public static string NotIn(string fieldName, string forbiddenValues) =>
		$"{fieldName} نباید یکی از مقادیر غیرمجاز باشد: {forbiddenValues}";

	// خطاهای خاص ایرانی
	public static string NationalCode(string fieldName) =>
		$"{fieldName} کد ملی معتبری نیست";

	public static string IranPhoneNumber(string fieldName) =>
		$"{fieldName} شماره تلفن ایران معتبری نیست";

	public static string IranMobileNumber(string fieldName) =>
		$"{fieldName} شماره موبایل ایران معتبری نیست";

	public static string PostalCode(string fieldName) =>
		$"{fieldName} کد پستی معتبری نیست";

	public static string BankAccountNumber(string fieldName) =>
		$"{fieldName} شماره حساب بانکی معتبری نیست";

	public static string ShabaNumber(string fieldName) =>
		$"{fieldName} شماره شبا معتبری نیست";

	// خطاهای رمز عبور
	public static string PasswordStrength(string fieldName) =>
		$"{fieldName} باید حداقل شامل یک حروف بزرگ، کوچک، عدد و کاراکتر خاص باشد";

	public static string PasswordMinLength(string fieldName, int minLength) =>
		$"حداقل طول {fieldName} باید {minLength} کاراکتر باشد";

	public static string PasswordConfirmation(string fieldName) =>
		$"تایید {fieldName} با {fieldName} مطابقت ندارد";

	// خطاهای فایل
	public static string FileSize(string fieldName, long maxSizeInBytes) =>
		$"حجم {fieldName} نباید بیشتر از {maxSizeInBytes / 1024 / 1024} مگابایت باشد";

	public static string FileExtension(string fieldName, string allowedExtensions) =>
		$"فرمت {fieldName} معتبر نیست. فرمت‌های مجاز: {allowedExtensions}";

	public static string ImageFormat(string fieldName) =>
		$"{fieldName} باید یک تصویر معتبر باشد";

	// خطاهای شرطی
	public static string When(string fieldName, string condition) =>
		$"{fieldName} در شرایط {condition} الزامی است";

	public static string Unless(string fieldName, string condition) =>
		$"{fieldName} در غیر از شرایط {condition} الزامی است";

	// خطاهای اعتبارسنجی سفارشی
	public static string Custom(string fieldName, string errorMessage) =>
		$"{fieldName}: {errorMessage}";

	public static string MustBeTrue(string fieldName) =>
		$"{fieldName} باید صحیح باشد";

	public static string MustBeFalse(string fieldName) =>
		$"{fieldName} باید غلط باشد";

	// خطاهای کلی
	public static string InvalidValue(string fieldName) =>
		$"مقدار {fieldName} نامعتبر است";

	public static string DuplicateValue(string fieldName) =>
		$"{fieldName} تکراری است";

	public static string NotFound(string fieldName) =>
		$"{fieldName} یافت نشد";

	public static string AccessDenied(string fieldName) =>
		$"دسترسی به {fieldName} مجاز نیست";

	// خطاهای JSON و XML
	public static string InvalidJson(string fieldName) =>
		$"{fieldName} فرمت JSON معتبری ندارد";

	public static string InvalidXml(string fieldName) =>
		$"{fieldName} فرمت XML معتبری ندارد";

	// خطاهای GUID
	public static string InvalidGuid(string fieldName) =>
		$"{fieldName} شناسه یکتای معتبری نیست";

	// خطاهای IP
	public static string InvalidIPAddress(string fieldName) =>
		$"{fieldName} آدرس IP معتبری نیست";

	// خطاهای دامنه
	public static string InvalidDomain(string fieldName) =>
		$"{fieldName} نام دامنه معتبری نیست";
}
