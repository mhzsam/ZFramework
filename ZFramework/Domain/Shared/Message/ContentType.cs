using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Message
{
	public static class ContentTypes
	{
		public const string Json = "application/json";
		public const string Xml = "application/xml";
		public const string Html = "text/html";
		public const string PlainText = "text/plain";
		public const string FormUrlEncoded = "application/x-www-form-urlencoded";
		public const string MultipartFormData = "multipart/form-data";
		public const string OctetStream = "application/octet-stream";
		public const string Csv = "text/csv";
		public const string Pdf = "application/pdf";
	}
}
