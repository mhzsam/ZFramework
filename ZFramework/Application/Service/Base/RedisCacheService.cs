using Domain.Shared.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Service.Base
{
	public class RedisCacheService : ICacheService
	{
		private readonly IDistributedCache _distributedCache;
		private readonly int _defaultExpirationSeconds;

		public RedisCacheService(IDistributedCache distributedCache, int defaultExpirationSeconds = 300)
		{
			_distributedCache = distributedCache;
			_defaultExpirationSeconds = defaultExpirationSeconds;
		}

		public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options = null)
		{
			try
			{
				var cacheOptions = options ?? new DistributedCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_defaultExpirationSeconds)
				};

				var jsonData = JsonSerializer.Serialize(value);
				await _distributedCache.SetStringAsync(key, jsonData, cacheOptions);
			}
			catch
			{
				// Redis قطع شده، خطا نده
				//لاگ زده شود 
			}
		}

		public async Task<T?> GetAsync<T>(string key)
		{
			try
			{
				var jsonData = await _distributedCache.GetStringAsync(key);
				if (jsonData != null)
					return JsonSerializer.Deserialize<T>(jsonData);
			}
			catch
			{
				// Redis قطع شده، مقدار پیش‌فرض برگردان
				//لاگ زده شود 

			}

			return default;
		}

		public async Task RemoveAsync(string key)
		{
			try
			{
				await _distributedCache.RemoveAsync(key);
				//لاگ زده شود 

			}
			catch
			{
				// Redis قطع شده، خطا نده
			}
		}
	}
}
