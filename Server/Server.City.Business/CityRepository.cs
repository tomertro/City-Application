using City.Common;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Server.City.Business
{
  public class CityRepository : ICityRepository
  {
    public IEnumerable<CityModel> GetCities()
    {
      IEnumerable<CityModel> result = null;
      var config = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        PrepareHeaderForMatch = args => args.Header.ToLower(),
      };
      using (var reader = new StreamReader(@".\bin\debug\netcoreapp3.1\lib\world-cities_csv.csv"))
      {
        using (var csv = new CsvReader(reader, config))
        {
          result = csv.GetRecords<CityModel>().ToList();
         
        }
      }
      return result;
    }
  }
}
