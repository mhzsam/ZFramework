using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Presentation.Extensions
{
	public static class ModelStateExtensions
	{
		/// <summary>
		/// تمام پیام‌های خطا از ModelState را جمع‌آوری می‌کند
		/// </summary>
		public static List<string> ToErrorList(this ModelStateDictionary modelState)
		{
			if (modelState == null)
				return new List<string>();

			return modelState
				.Where(ms => ms.Value.Errors.Count > 0)
				.SelectMany(kvp => kvp.Value.Errors.Select(e => e.ErrorMessage))
				.ToList();
		}
	}
}
