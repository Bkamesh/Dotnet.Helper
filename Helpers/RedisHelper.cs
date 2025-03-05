using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace dotnet.helper.Helpers;

public class RedisCache
{
    private readonly IDistributedCache _cache;
    public RedisCache(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task SetAsync<T>(string key, T value)
    {
        try
        {
            var cache = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key,cache,new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(35000)
            });
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var cache = await _cache.GetStringAsync(key) ?? string.Empty;
        var value =  JsonSerializer.Deserialize<T>(cache) ?? default;
        return  value;
    }
}