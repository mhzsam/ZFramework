using Domain.Exception;
using Domain.Shared.Message;
using Domain.Shared.Models;
using System.Net;
using System.Text.Json;

public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			context.Response.ContentType = "application/json";

			int statusCode = ex switch
			{
				UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
				CustomException => (int)HttpStatusCode.BadRequest,
				_ => (int)HttpStatusCode.InternalServerError
			};

			context.Response.StatusCode = statusCode;

			ResponseModel? result = ex switch
			{
				CustomException => ResponseModel.Fail(ex.Message, JsonSerializer.Serialize(ex.InnerException)),
				UnauthorizedAccessException => ResponseModel.Fail(ErrorText.Auth.Unauthorized, ex.Message),
				_ => ResponseModel.Fail(ErrorText.Network.InternalServerError, ex.Message + "\n" + ex.InnerException ?? string.Empty)
			};

			if (result != null)
				await context.Response.WriteAsJsonAsync(result);
		}

	}
}
