using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    Description = "Capital of Poland."
                },
                new CityDTO()
                {
                    Id = 2,
                    Name = "Berlin",
                    Description = "Capital of Germany."
                },
                new CityDTO()
                {
                    Id = 3,
                    Name = "Praga",
                    Description = "Capital of Czech Republic."
                },
            };
        }
    }
}
