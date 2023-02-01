using CarShareRestApi.Manager;
using CarShareRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarShareRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private CarManager _manager = new CarManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<Car>> GetAll()
        {
            List<Car> result = _manager.GetAllCars();
            if(result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            return Ok(_manager.GetCar(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            Car createdCar = new Car();
            createdCar = _manager.AddCar(newCar);
            return Created("api/CarRental/" + createdCar.Id, createdCar);
        }

        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car carToBeDeleted = _manager.GetCar(id);
            _manager.DeleteCar(id);
            return Ok(carToBeDeleted);
        }
    }
}
