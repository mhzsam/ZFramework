using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
	public static class ConvertHelper
	{
		// تبدیل تاریخ میلادی به فارسی (yyyy/MM/dd)
		public static string ToPersianDate(this DateTime? date, bool includeTime = false)
		{
			if (!date.HasValue)
				return string.Empty;

			var pc = new PersianCalendar();
			var d = date.Value;

			string persianDate = $"{pc.GetYear(d):0000}/{pc.GetMonth(d):00}/{pc.GetDayOfMonth(d):00}";

			if (includeTime)
			{
				persianDate += $" {d.Hour:00}:{d.Minute:00}:{d.Second:00}";
			}

			return persianDate;
		}

		public static string ToPersianDate(this DateTime date, bool includeTime = false)
		{
			return ((DateTime?)date).ToPersianDate(includeTime);
		}


		// تبدیل اینام به اینت
		public static int ToInt(this Enum value) => Convert.ToInt32(value);

		// گرفتن توضیح (Description) اینام
		public static string GetDescription(this Enum value)
		{
			var field = value.GetType().GetField(value.ToString());
			var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
			return attr?.Description ?? value.ToString();
		}

		// تبدیل رشته به اینت ایمن
		public static int ToInt(this string value, int defaultValue = 0)
		{
			return int.TryParse(value, out int result) ? result : defaultValue;
		}

		// تبدیل رشته به تاریخ ایمن
		public static DateTime ToDateTime(this string value, DateTime defaultValue)
		{
			return DateTime.TryParse(value, out var result) ? result : defaultValue;
		}
	}
}
