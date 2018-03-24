using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.SingleOrDefault(x => x.Id == cityId);

            if (city == null)
                return NotFound();

            return Ok(city.PointsOfInterests);
        }

        [HttpGet("{cityId}/pointsofinterest/{pointOfInterestId}")]
        public IActionResult GetSinglePointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.SingleOrDefault(x => x.Id == cityId);

            if (city == null)
                return NotFound();
            var pointOfInterest = city.PointsOfInterests.SingleOrDefault(x => x.Id == pointOfInterestId);

            if (pointOfInterest == null)
                return NotFound();

            return Ok(pointOfInterest);
        }
    }
}
