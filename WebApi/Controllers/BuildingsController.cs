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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildings(int id, Building building)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            //buscar producto
            var resultBuildig = await this.buildingRepository.GetByIdAsync(id);

            if (resultBuildig == null)
            {
                var noEncontrado = new
                {
                    codigo = 200,
                    status = "success",
                    objeto = "No encontrado"
                };
                return Ok(noEncontrado);
            }

            resultBuildig.Name = building.Name;
            resultBuildig.Address = building.Address;
            resultBuildig.Phone = building.Phone;
            resultBuildig.Country = building.Country;
            resultBuildig.State = building.State;
            resultBuildig.City = building.City;

            var updatedProduct = await this.buildingRepository.UpdateAsync(resultBuildig);

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            //buscar building
            var resultBuilding = await this.buildingRepository.GetByIdAsync(id);
            if (resultBuilding == null)
            {
                var noEncontrado = new
                {
                    codigo = 200,
                    status = "success",
                    objeto = "No encontrado"
                };
                return Ok(noEncontrado);
            }

            await this.buildingRepository.DeleteAsync(resultBuilding);
            var buildingEliminado = new
            {
                codigo = 200,
                status = "se elimino correctamente",
                objeto = resultBuilding
            };
            return Ok(buildingEliminado);
        }
    }
}