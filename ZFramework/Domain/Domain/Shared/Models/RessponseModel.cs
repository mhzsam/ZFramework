using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Models
{
	public record ResponseModel(
	bool IsSucceeded,
	List<string>? Errors,
	string? ErrorDescription
)
	{
		public static ResponseModel Success()
			=> new(true, null, null);

		public static ResponseModel Fail(string? error, string? desc = null)
			=> new(false, new List<string> { error ?? string.Empty }, desc);

		public static ResponseModel Fail(List<string>? errors, string? desc = null)
			=> new(false, errors, desc);
		
	}
	public record ResponseModel<T>(
	 bool IsSucceeded,
	 T Result,
	 List<string>? Errors,
	 string? ErrorDescription
 )
	{
		// موفق با نتیجه
		public static ResponseModel<T> Success(T result)
			=> new(true, result, null, null);

		// موفق بدون نتیجه
		public static ResponseModel<T> Success()
			=> new(true, default, null, null);

		// شکست با یک پیام
		public static ResponseModel<T> Fail(string error, string? errorDescription = null)
			=> Fail(new List<string> { error }, errorDescription);

		// شکست با چند پیام
		public static ResponseModel<T> Fail(List<string> errors, string? errorDescription = null)
			=> new(false, default, errors, errorDescription);
	}

	public record Pagination(int TotalItems, int PageNumber, int PageSize);

	public record ResponseModelWithPagination<T>(
		bool IsSucceeded,
		T Result,
		Pagination Pagination,
		List<string> Errors,
		string? ErrorDescription
	)
	{
		public static ResponseModelWithPagination<T> Success(
			T result, int totalItems, int pageNumber, int pageSize
		)
			=> new(true, result, new Pagination(totalItems, pageNumber, pageSize), null, null);

		public static ResponseModelWithPagination<T> Fail(
			string error,
			string? errorDescription
		)
			=> Fail(new List<string> { error }, errorDescription);

		public static ResponseModelWithPagination<T> Fail(
			List<string> errors,
			string? errorDescription = null
		)
			=> new(false, default, null, errors, errorDescription);
	}
}
