using City.Common;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityApplicationUnitTes
{
  public class DummyMemoryCache : IMemoryCache
  {
    private Dictionary<string,CityModel> _cache = new  Dictionary<string, CityModel>();
    public ICacheEntry CreateEntry(object key)
    {
      return null;
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public void Remove(object key)
    {
      throw new NotImplementedException();
    }

    public bool TryGetValue(object key, out object value)
    {
      if (_cache.ContainsKey(key.ToString()))
      {
        value = _cache[key.ToString()];
        return true;
      }
     
        value = null;
        return false;
      
      
        
    }
  }
}
