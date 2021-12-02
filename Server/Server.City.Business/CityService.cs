using City.Common;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server.City.Business
{
  public class CityService
  {
    private IMemoryCache _cache;
    private ICityRepository _cityRepository;

    public CityService(IMemoryCache cache, ICityRepository cityRepository)
    {
      _cache = cache;
      _cityRepository = cityRepository;
    }
    public async Task<IEnumerable<CityModel>> GetCities(string name)
    {
      
      IEnumerable<CityModel> result = null;
      result = await Task.Factory.StartNew(() =>
      {
        var entry = GetFromCache(name);
        if (entry != null) return entry;
        var cities = _cityRepository.GetCities();
        cities = cities.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        SetCache(name, cities);
        return cities; 
      });

      return result;
      
     
    }

    private void SetCache( string request, IEnumerable<CityModel> cities)
    {
      if (cities == null) return;
      try
      {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            // Keep in cache for this time, reset time if accessed.
            .SetSlidingExpiration(TimeSpan.FromHours(8));
        _cache.Set(request, cities, cacheEntryOptions);
      }
      catch { }
      
      
    }

    private IEnumerable<CityModel>  GetFromCache(string request)
    {
      IEnumerable<CityModel> cacheEntry;
      if (!_cache.TryGetValue(request, out cacheEntry))
        return null;
      return cacheEntry;

    }
  }
}
