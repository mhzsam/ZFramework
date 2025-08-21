using Domain.Shared.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Base
{
	public class MemoryCacheService : ICacheService
	{
		private readonly IMemoryCache _memoryCache;
		private readonly int _defaultExpirationSeconds;

		public MemoryCacheService(IMemoryCache memoryCache, int defaultExpirationSeconds)
		{
			_memoryCache = memoryCache;
			_defaultExpirationSeconds = defaultExpirationSeconds;
		}

		public Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options = null)
		{
			var memoryOptions = new MemoryCacheEntryOptions();

			if (options != null)
			{
				if (options.AbsoluteExpirationRelativeToNow.HasValue)
					memoryOptions.AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow;
				if (options.SlidingExpiration.HasValue)
					memoryOptions.SlidingExpiration = options.SlidingExpiration;
			}
			else
			{
				memoryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_defaultExpirationSeconds);
			}

			_memoryCache.Set(key, value, memoryOptions);
			return Task.CompletedTask;
		}

		public Task<T?> GetAsync<T>(string key)
		{
			_memoryCache.TryGetValue(key, out var value);
			return Task.FromResult((T)value);
		}

		public Task RemoveAsync(string key)
		{
			_memoryCache.Remove(key);
			return Task.CompletedTask;
		}
	}

}
