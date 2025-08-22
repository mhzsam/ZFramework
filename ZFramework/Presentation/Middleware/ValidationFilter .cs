using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;
using Domain.Shared.Models;
using System.Linq;

public class ValidationFilter : IActionFilter
{
	public void OnActionExecuting(ActionExecutingContext context)
	{
		foreach (var arg in context.ActionArguments.Values)
		{
			if (arg == null) continue;

			var validatorType = typeof(IValidator<>).MakeGenericType(arg.GetType());
			var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

			if (validator != null)
			{
				var result = validator.Validate(new FluentValidation.ValidationContext<object>(arg));
				if (!result.IsValid)
				{
					var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

					// برگردوندن ResponseModel<T>
					var responseType = typeof(ResponseModel<>).MakeGenericType(arg.GetType());
					var response = Activator.CreateInstance(responseType, false, default, errors, "خطا در مدل ارسالی");

					// بسته به اینکه Controller action نیاز به IActionResult دارد
					context.Result = new JsonResult(response)
					{
						StatusCode = 400
					};
					return;
				}
			}
		}
	}

	public void OnActionExecuted(ActionExecutedContext context) { }
}
