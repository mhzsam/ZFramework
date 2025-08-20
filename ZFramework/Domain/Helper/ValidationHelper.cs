using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Helper
{
	public static class ValidationHelper
	{
		public static bool IsValidEmail(this string email)
		{
			if (string.IsNullOrWhiteSpace(email)) return false;
			try
			{
				var addr = new MailAddress(email);
				return addr.Address == email;
			}
			catch { return false; }
		}
		public static bool IsValidUrl(this string url)
		{
			if (string.IsNullOrWhiteSpace(url)) return false;
			return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
				   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
		}
		// چک شماره موبایل ایران
		public static bool IsValidIranMobile(this string mobile)
		{
			if (string.IsNullOrEmpty(mobile)) return false;
			// الگو: 09xxxxxxxxx
			return Regex.IsMatch(mobile, @"^09\d{9}$");
		}

		// چک شماره کارت بانکی (16 رقم)
		public static bool IsValidCardNumber(this string cardNumber)
		{
			if (string.IsNullOrEmpty(cardNumber)) return false;
			var digitsOnly = Regex.Replace(cardNumber, @"[^\d]", "");
			if (digitsOnly.Length != 16) return false;

			// الگوریتم لونا
			int sum = 0;
			for (int i = 0; i < 16; i++)
			{
				int digit = int.Parse(digitsOnly[i].ToString());
				if (i % 2 == 0) digit *= 2;
				if (digit > 9) digit -= 9;
				sum += digit;
			}
			return sum % 10 == 0;
		}
		// چک شبا ایران
		public static bool IsValidSheba(this string sheba)
		{
			if (string.IsNullOrEmpty(sheba)) return false;
			sheba = sheba.Replace("IR", "").Trim();
			if (!Regex.IsMatch(sheba, @"^\d{24}$")) return false;

			// تبدیل IR به 1827 و محاسبه مود 97
			string numeric = "1827" + sheba;
			BigInteger total = BigInteger.Parse(numeric);
			return total % 97 == 1;
		}
	}


}
