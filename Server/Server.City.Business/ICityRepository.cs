using City.Common;
using System.Collections.Generic;

namespace Server.City.Business
{
  public interface ICityRepository
  {
    IEnumerable<CityModel> GetCities();
  }
}
