using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JQuaryClient.Models;

namespace JQuaryClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private List<Destination> _destinations;
        public DestinationsController()
        {
            _destinations = new List<Destination>();

            _destinations.Add(new Destination { Id = 1, CityName = "Seattle", Airport = "Sea-Tac" });
            _destinations.Add(new Destination { Id = 2, CityName = "New-york", Airport = "JFK" });
            _destinations.Add(new Destination { Id = 3, CityName = "Amsterdam", Airport = "Schiphol" });
            _destinations.Add(new Destination { Id = 4, CityName = "London", Airport = "Heathrow" });
            _destinations.Add(new Destination { Id = 5, CityName = "Paris", Airport = "Charles De Gaulle" });
        }

        // GET api/Destinations
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get()
        {
             return _destinations;
        }

        // GET api/Destinations/5
        [HttpGet("{id}")]
        public Destination Get(int id)
        {
            var destination = _destinations.Where(d => d.Id == id).FirstOrDefault();

          

            return destination;
        }

        // POST api/Destinations
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Destinations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Destinations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
