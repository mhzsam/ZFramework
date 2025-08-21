using Domain.Shared.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Service.Base
{
	public class RedisCacheService : ICacheService
	{
		private readonly IDistributedCache _distributedCache;
		private readonly int _defaultExpirationSeconds;

		public RedisCacheService(IDistributedCache distributedCache, int defaultExpirationSeconds)
		{
			_distributedCache = distributedCache;
			_defaultExpirationSeconds = defaultExpirationSeconds;
		}

		public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options = null)
		{
			var cacheOptions = options ?? new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_defaultExpirationSeconds)
			};

			var jsonData = JsonSerializer.Serialize(value);
			await _distributedCache.SetStringAsync(key, jsonData, cacheOptions);
		}

		public async Task<T?> GetAsync<T>(string key)
		{
			var jsonData = await _distributedCache.GetStringAsync(key);
			return jsonData == null ? default : JsonSerializer.Deserialize<T>(jsonData);
		}

		public async Task RemoveAsync(string key)
		{
			await _distributedCache.RemoveAsync(key);
		}
	}

}
