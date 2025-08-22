using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;

namespace Domain.Shared.QueryableEngin
{
	[AttributeUsage(AttributeTargets.Property)]
	public class QueryableAttribute : Attribute { }

	public class QueryParameters
	{
		public string? Filters { get; set; } = null;
		public string? Sorts { get; set; } = null;
		public int Page { get; set; } = 1;
		public int PageSize { get; set; } = 20;
	}

	public class QueryValidationResult
	{
		public bool IsValid => !Errors.Any();
		public List<string> Errors { get; set; } = new();
	}

	public static class QueryValidator
	{
		public static QueryValidationResult Validate<T>(string filterExpression)
		{
			var result = new QueryValidationResult();

			// جمع‌آوری لیست Propertyهای Root
			var rootProperties = typeof(T)
				.GetProperties()
				.Where(p => Attribute.IsDefined(p, typeof(QueryableAttribute)))
				.ToDictionary(p => p.Name, p => p);

			// استخراج مسیرهای Navigation کامل
			var navigationPaths = GetQueryablePaths(typeof(T));

			// استخراج تمام نام‌هایی که توی expression اومدن
			var propPattern = @"[A-Za-z_][A-Za-z0-9_]*(?:\.[A-Za-z_][A-Za-z0-9_]*)*";
			var matches = Regex.Matches(filterExpression ?? string.Empty, propPattern)
							   .Select(m => m.Value)
							   .Distinct();

			foreach (var prop in matches)
			{
				if (prop.Contains("."))
				{
					// Navigation
					if (!navigationPaths.Contains(prop))
					{
						result.Errors.Add($"Navigation property '{prop}' is not allowed or does not exist.");
					}
				}
				else
				{
					// Root property
					var inRoot = rootProperties.ContainsKey(prop);
					var inNav = navigationPaths.Any(p => p.Split('.')[0] == prop);

					if (!inRoot)
					{
						result.Errors.Add($"Root property '{prop}' is not allowed.");
					}
					else if (inNav)
					{
						// اگر در هر دو وجود دارد، مشکلی نیست ولی ممکن است کاربر اشتباه کند
						// اینجا فقط Conflict را ثبت می‌کنیم برای اطلاع
						result.Errors.Add($"Ambiguous property '{prop}': also exists in navigation path. Specify full path if you mean navigation.");
					}
				}
			}

			return result;
		}

		private static HashSet<string> GetQueryablePaths(Type type, string prefix = "")
		{
			var paths = new HashSet<string>();
			foreach (var prop in type.GetProperties())
			{
				if (Attribute.IsDefined(prop, typeof(QueryableAttribute)))
				{
					var path = string.IsNullOrEmpty(prefix) ? prop.Name : $"{prefix}.{prop.Name}";
					paths.Add(path);

					if (!prop.PropertyType.IsPrimitive &&
						prop.PropertyType != typeof(string) &&
						!prop.PropertyType.IsValueType &&
						!typeof(IEnumerable<object>).IsAssignableFrom(prop.PropertyType))
					{
						// ادامه مسیر Navigation
						foreach (var sub in GetQueryablePaths(prop.PropertyType, path))
						{
							paths.Add(sub);
						}
					}
				}
			}
			return paths;
		}
	}

	public static class QueryProcessor
	{
		public static IQueryable<T> ApplyQuery<T>(this IQueryable<T> source, QueryParameters parameters)
		{
			// Validate
			var validation = QueryValidator.Validate<T>(parameters.Filters);
			if (!validation.IsValid)
				throw new InvalidOperationException(string.Join("; ", validation.Errors));

			// Filtering
			if (!string.IsNullOrWhiteSpace(parameters.Filters))
				source = source.Where(parameters.Filters);

			// Sorting
			if (!string.IsNullOrWhiteSpace(parameters.Sorts))
				source = source.OrderBy(parameters.Sorts);

			// Paging
			var skip = (parameters.Page - 1) * parameters.PageSize;
			return source.Skip(skip).Take(parameters.PageSize);
		}
	}
}
