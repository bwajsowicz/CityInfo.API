﻿using CityInfo.API.Models;
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
            if (pointOfInterest == null)
                return BadRequest();

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
            // FluentValidation might help.

            if (pointOfInterest == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (pointOfInterest.Name == pointOfInterest.Description)
                ModelState.AddModelError("Description", "Description should be different from the name.");

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
    }
}
