using Application.DTO.Captcha;
using Microsoft.Extensions.Caching.Memory;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Concurrent;



namespace Application.Helper
{
    public static class CaptchaHelper
    {
        private static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public static GetCaptchaModel GetCaptcha()
        {
            try
            {
                if (!IsFontReady())
                    throw new Exception("font not found");
                Random random = new Random();

                int key = random.Next(10000, 99999);
                string token = TokenGenerator();

                FontCollection collection = new();
                string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "SedgwickAveDisplay.ttf");
                FontFamily family = collection.Add(filePath);
                Font font = family.CreateFont(80, FontStyle.Bold);
                Image imgText = new Image<Rgba32>(250, 100);
                imgText.Mutate(x => x.DrawText(key.ToString(), font, Color.ParseHex(String.Format("#{0:X6}", random.Next(0x1000000))), new PointF(10, 20)));

                var point = GenerateRandomPoint();
                float thinkness = 4;
                var tt = Convert.ToByte(random.Next(256));
                imgText.Mutate(x => x.DrawBeziers(Color.FromRgba(Convert.ToByte(random.Next(256)), Convert.ToByte(random.Next(256)), Convert.ToByte(random.Next(256)), Convert.ToByte(random.Next(256))), 5, GenerateRandomPoint()));
                imgText.Mutate(x => x.DrawBeziers(Color.FromRgba(Convert.ToByte(random.Next(256)), Convert.ToByte(random.Next(256)), Convert.ToByte(random.Next(256)), Convert.ToByte(random.Next(256))), 5, GenerateRandomPoint()));
                MemoryStream ms = new MemoryStream();
                imgText.Save(ms, new PngEncoder());

                string base64 = Convert.ToBase64String(ms.ToArray());

                MemoryCacheOptions cacheOptions = new MemoryCacheOptions();

                _cache.Set(token, key, TimeSpan.FromSeconds(60));

                return new GetCaptchaModel() { Base64Image = base64, CaptchaToken = token };
            }
            catch (Exception ex)
            {
                throw new Exception("problem from generate captch");
            }
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

        private static bool IsFontReady()
        {
            string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "SedgwickAveDisplay.ttf");
            if (!File.Exists(filePath))
            {
                var client = new HttpClient();
                var res = client.GetAsync("https://mhzsamstorage.storage.iran.liara.space/SedgwickAveDisplay.ttf").Result;
                if (!res.IsSuccessStatusCode)
                {
                    return false;
                }
                var fontBytes = res.Content.ReadAsByteArrayAsync().Result;
                File.WriteAllBytes(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "SedgwickAveDisplay.ttf"), fontBytes);

            }
            return true;
        }

        private static string TokenGenerator()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }
        private static PointF[] GenerateRandomPoint()
        {
            List<PointF> points = new List<PointF>();


            for (int i = 0; i < 10; i++)
            {
                points.Add(new PointF(new Random().Next(0, 250), new Random().Next(0, 100)));
            }


            return points.ToArray();
        }



    }
}
