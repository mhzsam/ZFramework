using Mapster;

namespace Domain.Shared.Models
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
		public static ResponseModel<T> Success(T result)
			=> new(true, result, null, null);

		public static ResponseModel<T> Success()
			=> new(true, default, null, null);

		public static ResponseModel<T> Fail(string error, string? errorDescription = null)
			=> Fail(new List<string> { error }, errorDescription);

		public static ResponseModel<T> Fail(List<string> errors, string? errorDescription = null)
			=> new(false, default, errors, errorDescription);


	}

	public record Pagination(int TotalItems, int PageNumber, int PageSize);

	public record PagingResponseModel<T>(
		bool IsSucceeded,
		IEnumerable<T> Result,
		Pagination Pagination,
		List<string> Errors,
		string? ErrorDescription
	)
	{
		public static PagingResponseModel<T> Success(
			IEnumerable<T> result, int totalItems, int pageNumber, int pageSize
		)
			=> new(true, result, new Pagination(totalItems, pageNumber, pageSize), null, null);

		public static PagingResponseModel<T> Success()
			=> new(true, default, new Pagination(0, 0, 0), null, null);

		public static PagingResponseModel<T> Fail(string error, string? errorDescription = null)
			=> Fail(new List<string> { error }, errorDescription);

		public static PagingResponseModel<T> Fail(List<string> errors, string? errorDescription = null)
			=> new(false, default, null, errors, errorDescription);
	}


	public static class PagingResponseExtensions
	{
		public static PagingResponseModel<TDestination> MapTo<TSource, TDestination>(
			this PagingResponseModel<TSource> source
		)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			return new PagingResponseModel<TDestination>(
				source.IsSucceeded,
				source.Result?.Adapt<IEnumerable<TDestination>>(),
				source.Pagination,
				source.Errors,
				source.ErrorDescription
			);
		}
	}
}
