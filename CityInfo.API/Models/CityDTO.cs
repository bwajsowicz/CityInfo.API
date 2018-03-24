﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointsOfInterest
            => PointsOfInterests.Count;
        public ICollection<PointsOfInterestDTO> PointsOfInterests { get; set; }
            = new List<PointsOfInterestDTO>();
        
    }
}
