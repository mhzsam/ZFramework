using Domain.Shared.Models;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
	public static class HashIdHelper
	{
		private static AppSettings? _appSettings;

		public static void Configure(AppSettings? appSettings)
		{
			_appSettings = appSettings;
		}
		private static readonly Hashids _hashids = new("MyAppSecretSalt", 8);

		public static string Encode(int id) => _hashids.Encode(id);
		public static string Encode(long id) => _hashids.EncodeLong(id);

		public static int? DecodeInt(string hash)
		{
			var numbers = _hashids.Decode(hash);
			return numbers.Length > 0 ? numbers[0] : null;
		}

		public static long? DecodeLong(string hash)
		{
			var numbers = _hashids.DecodeLong(hash);
			return numbers.Length > 0 ? numbers[0] : null;
		}

		// پشتیبانی از چندین مقدار (در صورت نیاز)
		public static string EncodeMany(params int[] ids) => _hashids.Encode(ids);
		public static string EncodeMany(params long[] ids) => _hashids.EncodeLong(ids);

		public static int[] DecodeManyInt(string hash) => _hashids.Decode(hash);
		public static long[] DecodeManyLong(string hash) => _hashids.DecodeLong(hash);
	}
}
