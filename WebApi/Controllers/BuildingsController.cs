using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingRepository buildingRepository;

        public BuildingsController(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;
        }


        [HttpGet]
        public IActionResult GetBuildings()
        {
            return Ok(this.buildingRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> PostBuildings(Building building)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var entitybuilding = new Building
            {
                Name = building.Name,
                Address = building.Address,
                Phone = building.Phone,
                Country = building.Country,
                State = building.State,
                City = building.City
            };
            var newBuilding = await this.buildingRepository.CreateAsync(entitybuilding);
            return Ok(newBuilding); ;

        }
    }
}