using Application.DTO.Captcha;
using Microsoft.Extensions.Caching.Memory;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;
using System.Security.Cryptography;
using SixLabors.ImageSharp.Drawing.Processing;

namespace Application.Helper
{
	public static class CaptchaHelper
	{
		private static readonly MemoryCache _cache = new(new MemoryCacheOptions
		{
			SizeLimit = 10000 // محدود کردن تعداد آیتم‌ها
		});

		private static readonly Font _font;
		private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

		static CaptchaHelper()
		{
			string filePath = Path.Combine(AppContext.BaseDirectory, "Font", "SedgwickAveDisplay.ttf");
			if (!File.Exists(filePath))
			{
				using var client = new HttpClient();
				var fontBytes = client.GetByteArrayAsync("اگر در کلود است ").Result;
				File.WriteAllBytes(filePath, fontBytes);
			}

			FontCollection collection = new();
			FontFamily family = collection.Add(filePath);
			_font = family.CreateFont(80, FontStyle.Bold);
		}

		public static GetCaptchaModel GetCaptcha()
		{
			int key = GetRandomNumber(10000, 99999);
			string token = TokenGenerator();

			using var imgText = new Image<Rgba32>(250, 100);
			imgText.Mutate(x =>
			{
				x.DrawText(key.ToString(), _font, GetRandomColor(), new PointF(10, 20));
				x.DrawBeziers(GetRandomColor(), 15, GenerateRandomPoints());
				x.DrawBeziers(GetRandomColor(), 5, GenerateRandomPoints());
			});

			using var ms = new MemoryStream();
			imgText.Save(ms, new PngEncoder());
			string base64 = Convert.ToBase64String(ms.ToArray());

			_cache.Set(token, key, new MemoryCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2),
				Size = 1
			});

			return new GetCaptchaModel { Base64Image = base64, CaptchaToken = token };
		}

		public static bool ValidateCaptcha(VaslidateCaptchaModel model)
		{
			var key = _cache.Get(model.CaptchaToken);
			if (key != null && model.Key == key.ToString())
			{
				_cache.Remove(model.CaptchaToken);
				return true;
			}
			return false;
		}

		private static string TokenGenerator()
		{
			Guid g = Guid.NewGuid();
			string GuidString = Convert.ToBase64String(g.ToByteArray());
			return GuidString.Replace("=", "").Replace("+", "");
		}

		private static PointF[] GenerateRandomPoints()
		{
			var points = new PointF[10];
			for (int i = 0; i < points.Length; i++)
			{
				points[i] = new PointF(GetRandomNumber(0, 250), GetRandomNumber(0, 100));
			}
			return points;
		}

		private static Color GetRandomColor()
		{
			byte[] rgb = new byte[4];
			_rng.GetBytes(rgb);
			return Color.FromRgba(rgb[0], rgb[1], rgb[2], 200);
		}

		private static int GetRandomNumber(int min, int max)
		{
			byte[] data = new byte[4];
			_rng.GetBytes(data);
			int value = BitConverter.ToInt32(data, 0) & int.MaxValue;
			return (value % (max - min)) + min;
		}
	}
}
