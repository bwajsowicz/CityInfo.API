using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{cityId}/pointsofinterest/{pointOfInterestId}", Name = "GetSinglePointOfInterest")]
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

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointsOfInterestForCreationDTO pointOfInterest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(x => x.Id == cityId);

            if (city == null)
                return NotFound();

            var pointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                x => x.PointsOfInterests).Max(x => x.Id);

            var finalPointOfInterest = new PointsOfInterestDTO()
            {
                Id = ++pointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterests.Add(finalPointOfInterest);

            return CreatedAtRoute("GetSinglePointOfInterest", new
            {
                cityId = cityId,
                pointOfInterestId = finalPointOfInterest.Id
            }, finalPointOfInterest);
        }

        [HttpPut("{cityId}/pointsofinterest/{pointOfInterestId}")]
        public IActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId,
            [FromBody] PointsOfInterestForUpdateDTO pointOfInterest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(x => x.Id == cityId);

            if (city == null)
                return NotFound();

            var pointOfInterestFromDataSore = city.PointsOfInterests.SingleOrDefault(x =>
            x.Id == pointOfInterestId);

            if (pointOfInterestFromDataSore == null)
                return NotFound();

            pointOfInterestFromDataSore.Name = pointOfInterest.Name;
            pointOfInterestFromDataSore.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{pointOfInterestId}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
            [FromBody] JsonPatchDocument<PointsOfInterestForUpdateDTO> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest(ModelState);

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(x => x.Id == cityId);

            if (city == null)
                return NotFound();

            var pointOfInterest = city.PointsOfInterests.SingleOrDefault(x => x.Id == pointOfInterestId);

            if (pointOfInterest == null)
                return NotFound();

            var pointOfInterestToUpdate = new PointsOfInterestForUpdateDTO()
            {
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            patchDoc.ApplyTo(pointOfInterestToUpdate, ModelState);

            if(!ModelState.IsValid)
                return BadRequest();

            TryValidateModel(pointOfInterestToUpdate);

            pointOfInterest.Name = pointOfInterestToUpdate.Name;
            pointOfInterest.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpDelete("{cityId}/pointsofinterest/{pointOfInterestId}")]
        public IActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.SingleOrDefault(x => x.Id == cityId);

            if (city == null)
                return NotFound();

            var pointOfInterestToRemove = city.PointsOfInterests.SingleOrDefault(x => x.Id == pointOfInterestId);

            if (pointOfInterestToRemove == null)
                return NotFound();

            city.PointsOfInterests.Remove(pointOfInterestToRemove);

            return NoContent();
        }
    }
}
