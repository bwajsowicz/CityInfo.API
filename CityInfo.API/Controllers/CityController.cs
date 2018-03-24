using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CityController : Controller
    {
        [HttpGet()]
        public JsonResult GetCities()
            => new JsonResult(CitiesDataStore.Current.Cities);

        [HttpGet("{id}")]
        public JsonResult GetSingleCity(int id)
            => new JsonResult(CitiesDataStore.Current.Cities.SingleOrDefault(x => x.Id == id));
    }
}
