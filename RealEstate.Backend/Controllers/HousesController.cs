using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RealEstate.Backend.Controllers
{
    [Route("api/houses")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly HousesService service;

        public HousesController(HousesService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<HouseDataModel>> Get() => service.GetHouses();

        [HttpGet("{name:length(2,3)}", Name = "GetHouse")]
        public ActionResult<HouseDataModel> Get(string name)
        {
            var house = service.GetHouse(name);
            if (house == null) return NotFound();
            else return house;
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, HouseDataModel newHouse)
        {
            var house = service.GetHouse(id);
            if (house == null) return NotFound();
            service.UpdateHouse(id, newHouse);
            return NoContent();
        }

        [HttpDelete("{name:length(2,3)}")]
        public IActionResult Delete(string id)
        {
            var house = service.GetHouse(id);
            if (house == null) return NotFound();
            service.DeleteHouse(id);
            return NoContent();
        }
    }
}
