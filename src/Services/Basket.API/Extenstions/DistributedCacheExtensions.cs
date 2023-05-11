using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Basket.API.Extenstions
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,string recordId,T date,
            TimeSpan? expireTime=null,TimeSpan? unesedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = expireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unesedExpireTime ?? TimeSpan.FromDays(1);

            var json = JsonSerializer.Serialize(date);
            await cache.SetStringAsync(recordId, json, options);
        }
    }
}
