using CityInfo.API.Models;
using System.Collections.Generic;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDTO> Cities { get; set; }
        
        public CitiesDataStore()
        {
            Cities = new List<CityDTO>
            {
                new CityDTO()
                {
                    Id = 1,
                    Name = "Warsaw",
                    Description = "Capital of Poland.",
                    PointsOfInterests = new List<PointsOfInterestDTO>()
                    {
                        new PointsOfInterestDTO()
                        {
                            Id = 1,
                            Name = "Warsaw Rising Museum",
                            Description = "Museum"
                        },
                        new PointsOfInterestDTO()
                        {
                            Id = 2,
                            Name = "PGE National Stadium ",
                            Description = "Statium"
                        }
                    }
                },
                new CityDTO()
                {
                    Id = 2,
                    Name = "Berlin",
                    Description = "Capital of Germany.",
                    PointsOfInterests = new List<PointsOfInterestDTO>()
                    {
                        new PointsOfInterestDTO()
                        {
                            Id = 3,
                            Name = "Brandenburg Gate",
                            Description = "Monument"
                        },
                        new PointsOfInterestDTO()
                        {
                            Id = 4,
                            Name = "Checkpoint Charlie",
                            Description = "Historic Site"
                        }
                    }
                },
                new CityDTO()
                {
                    Id = 3,
                    Name = "Prague",
                    Description = "Capital of Czech Republic.",
                     PointsOfInterests = new List<PointsOfInterestDTO>()
                    {
                        new PointsOfInterestDTO()
                        {
                            Id = 5,
                            Name = "Prague Castle",
                            Description = "Castle"
                        },
                        new PointsOfInterestDTO()
                        {
                            Id = 6,
                            Name = "Charles Bridge",
                            Description = "Bridge"
                        }
                    }
                },
            };
        }
    }
}
