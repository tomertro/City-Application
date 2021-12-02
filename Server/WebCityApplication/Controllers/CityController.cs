using City.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.City.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCityApplication.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CityController : ControllerBase
  {

    private readonly ILogger<CityController> _logger;
    private CityService _cityService;
    public CityController(ILogger<CityController> logger, CityService cityService)
    {
      _logger = logger;
      _cityService = cityService;
    }

    

    [HttpGet]    
    public async Task<ActionResult<IEnumerable<CityModel>>> GetCities(string name)
    {

      try
      {

        if (string.IsNullOrWhiteSpace(name))
        {
          return new List<CityModel>() { };
        }       
        IEnumerable<CityModel> result = null;
        result = await _cityService.GetCities(name);
        return result.ToList();

      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "GetCities Failure.");
        return  BadRequest(ex);

      }


    }
  }
}

