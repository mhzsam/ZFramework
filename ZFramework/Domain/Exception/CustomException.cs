using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exception
{
	public class CustomException : System.Exception
	{
		public int StatusCode { get; } = 400; // می‌تونی Default بذاری
		public object? AdditionalData { get; }

		public CustomException(string message)
			: base(message) { }

		public CustomException(string message, int statusCode)
			: base(message)
		{
			StatusCode = statusCode;
		}

		public CustomException(string message, int statusCode, object additionalData)
			: base(message)
		{
			StatusCode = statusCode;
			AdditionalData = additionalData;
		}


	}
}
