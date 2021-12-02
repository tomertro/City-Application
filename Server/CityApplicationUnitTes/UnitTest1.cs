using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.City.Business;
using System.Linq;

namespace CityApplicationUnitTes
{
  [TestClass]
  public class UnitTest1
  {
    [TestInitialize()]
    public void TestInitialize()
    {
      _cityService = new CityService(new DummyMemoryCache(), new DummyRepository());
    }
    private CityService _cityService;
    [TestMethod]
    public void Test_GetCities_ShouldReturnCity()
    {
      var result = _cityService.GetCities("pri").GetAwaiter().GetResult().ToList();
      Assert.IsTrue(result.Any());
    }
    [TestMethod]
    public void Test_GetCities_ShouldReturnEmpty()
    {
      var result = _cityService.GetCities("new").GetAwaiter().GetResult().ToList();
      Assert.IsFalse(result.Any());
    }
  }
}
