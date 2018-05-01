using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CityController : Controller
    {
        // There is no NotFound, because an empty collection is also a valid response. 
        [HttpGet()]
        public IActionResult GetCities()
            => Ok(CitiesDataStore.Current.Cities); 

        [HttpGet("{id}")]
        public IActionResult GetSingleCity(int id)
        {
            var city = CitiesDataStore.Current.Cities.SingleOrDefault(x => x.Id == id);

            if(city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
