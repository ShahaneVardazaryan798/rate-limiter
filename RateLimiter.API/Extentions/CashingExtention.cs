﻿using Microsoft.Extensions.Caching.Distributed;

namespace RateLimiter.API.Extentions
{
    public static class CashingExtention
    {
        public async static Task SetCahceValueAsync<T>(this IDistributedCache distributedCache, string key, T value, CancellationToken token = default(CancellationToken))
        {
            await distributedCache.SetAsync(key, value.ToByteArray(), token);
        }

        public async static Task<T> GetCacheValueAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken token = default(CancellationToken)) where T : class
        {
            var result = await distributedCache.GetAsync(key, token);
            return result.FromByteArray<T>();
        }
    }
}
