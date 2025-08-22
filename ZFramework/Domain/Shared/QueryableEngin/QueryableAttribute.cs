using Microsoft.VisualBasic;
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

			if (string.IsNullOrWhiteSpace(filterExpression))
				return result;

			// ساخت metadata
			var allowedPaths = BuildAllowedPaths<T>();

			// پارس کردن expression
			var propertyPaths = ParsePropertyPaths(filterExpression);

			// اعتبارسنجی هر path
			foreach (var path in propertyPaths)
			{
				if (!allowedPaths.Contains(path))
				{
					result.Errors.Add($"Property '{path}' is not allowed or does not exist.");
				}
			}

			return result;
		}
		private static HashSet<string> BuildAllowedPaths<T>()
		{
			var allowedPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			BuildAllowedPathsRecursive(typeof(T), "", allowedPaths, new HashSet<Type>());
			return allowedPaths;
		}

		private static void BuildAllowedPathsRecursive(Type type, string currentPath,
			HashSet<string> allowedPaths, HashSet<Type> visitedTypes)
		{
			if (visitedTypes.Contains(type))
				return;

			visitedTypes.Add(type);

			var queryableProperties = type.GetProperties()
				.Where(p => Attribute.IsDefined(p, typeof(QueryableAttribute)))
				.ToList();

			foreach (var prop in queryableProperties)
			{
				var propPath = string.IsNullOrEmpty(currentPath) ? prop.Name : $"{currentPath}.{prop.Name}";

				// اضافه کردن PascalCase
				allowedPaths.Add(propPath);

				// اضافه کردن camelCase
				var camelPath = ConvertToCamelPath(propPath);
				allowedPaths.Add(camelPath);

				// اگر complex type باشه، ادامه بده
				if (IsComplexType(prop.PropertyType))
				{
					var innerType = GetInnerType(prop.PropertyType);
					if (innerType != null)
					{
						BuildAllowedPathsRecursive(innerType, propPath, allowedPaths, visitedTypes);
					}
				}
			}

			visitedTypes.Remove(type);
		}
		private static List<string> ParsePropertyPaths(string expression)
		{
			var paths = new List<string>();

			// حذف string literals
			var noStrings = Regex.Replace(expression, @"""[^""]*""", "");

			// Pattern که property paths رو پیدا میکنه ولی method calls رو نه
			var pattern = @"\b([A-Za-z_][A-Za-z0-9_]*(?:\.[A-Za-z_][A-Za-z0-9_]*)+)(?!\s*\()";

			var matches = Regex.Matches(noStrings, pattern);

			foreach (Match match in matches)
			{
				var fullPath = match.Groups[1].Value;

				// اگر path با lambda parameter شروع میشه (چک ساده)
				// یعنی اگر قبل از => باشه
				var beforeArrow = noStrings.Substring(0, match.Index + match.Length);
				if (beforeArrow.Contains("=>"))
				{
					var parts = fullPath.Split('.');
					if (parts.Length > 1)
					{
						// اولین قسمت رو حذف کن (lambda parameter)
						fullPath = string.Join(".", parts.Skip(1));
					}
					else
					{
						continue; // اگر فقط parameter بود skip کن
					}
				}

				if (!string.IsNullOrEmpty(fullPath) && !IsReservedWord(fullPath))
				{
					paths.Add(fullPath);
				}
			}

			return paths.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
		}

		private static string RemoveLambdaParameterPrefix(string path, HashSet<string> lambdaParams)
		{
			var parts = path.Split('.');

			// اگر اولین قسمت lambda parameter باشه، حذفش کن
			if (parts.Length > 1 && lambdaParams.Contains(parts[0]))
			{
				return string.Join(".", parts.Skip(1));
			}

			return path;
		}
		private static string ConvertToCamelPath(string pascalPath)
		{
			var parts = pascalPath.Split('.');
			return string.Join(".", parts.Select(p =>
				char.ToLowerInvariant(p[0]) + p.Substring(1)));
		}

		private static Type GetInnerType(Type type)
		{
			// اگر Generic Collection باشه
			if (type.IsGenericType)
			{
				var genericArgs = type.GetGenericArguments();
				if (genericArgs.Length > 0)
					return genericArgs[0];
			}

			// اگر Array باشه
			if (type.IsArray)
				return type.GetElementType();

			if (type.IsGenericType)
			{
				var genericArgs = type.GetGenericArguments();
				if (genericArgs.Length > 0)
					return genericArgs[0];
			}

			var enumerableInterface = type.GetInterfaces()
										  .FirstOrDefault(i => i.IsGenericType &&
															   i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

			if (enumerableInterface != null)
				return enumerableInterface.GetGenericArguments()[0];


			return type;
		}

		private static bool IsComplexType(Type type)
		{
			return !type.IsPrimitive &&
				   type != typeof(string) &&
				   type != typeof(DateTime) &&
				   type != typeof(decimal) &&
				   type != typeof(Guid) &&
				   !type.IsEnum &&
				   !IsNullableOfSimpleType(type);
		}
		private static bool IsLambdaParameterPath(string path, string fullExpression)
		{
			var firstPart = path.Split('.')[0];

			// چک کن که آیا این parameter در یک lambda expression تعریف شده یا نه
			var lambdaPattern = $@"\b{Regex.Escape(firstPart)}\s*=>";
			return Regex.IsMatch(fullExpression, lambdaPattern);
		}

		private static bool IsNullableOfSimpleType(Type type)
		{
			if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Nullable<>))
				return false;

			var innerType = type.GetGenericArguments()[0];
			return innerType.IsPrimitive || innerType.IsEnum ||
				   innerType == typeof(DateTime) || innerType == typeof(decimal) ||
				   innerType == typeof(Guid);
		}

		private static bool IsReservedWord(string word)
		{
			var reservedWords = new[] { "true", "false", "null", "Contains", "StartsWith", "EndsWith" };
			return reservedWords.Contains(word, StringComparer.OrdinalIgnoreCase);
		}
	}
	public static class QueryProcessor
	{
		public static IQueryable<T> ApplyQuery<T>(this IQueryable<T> source, QueryParameters parameters)
		{
			//Validate
			//var validation = QueryValidator.Validate<T>(parameters.Filters);
			//if (!validation.IsValid)
			//	throw new InvalidOperationException(string.Join("; ", validation.Errors));

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
