using City.Common;
using Server.City.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityApplicationUnitTes
{
  public class DummyRepository : ICityRepository
  {
    private List<CityModel> _cityModels = new List<CityModel> { new CityModel() { Name = "Johannesburg", Country = "South Africa", SubCountry = "Gauteng", GeonameId = "993800",  },
      new CityModel() { Name = "Prizren", Country = "Kosovo", SubCountry = "Prizren", GeonameId = "786712",  }
    };
    
    public DummyRepository()
    {
      
    }
    public IEnumerable<CityModel> GetCities()
    {
      return _cityModels;
    }
  }
}
