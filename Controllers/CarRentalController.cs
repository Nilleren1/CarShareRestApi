using CarShareRestApi.Manager;
using CarShareRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CarShareRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private readonly CarDBManager _dbManager;
        
        public CarRentalController(CorolabPraktikDBContext context)
        {
            _dbManager = new CarDBManager(context);
        }

        [HttpGet]
        public ActionResult<List<RentalCar>> GetAllRentalCars()
        {
            List<RentalCar> rentalCars = _dbManager.GetAllRentalCars();

            if (!rentalCars.Any())
            {
                return NotFound("No Cars here");
            }
            return Ok(rentalCars);
        }

        //Update Rental Car from id
        [HttpPut("{id}")]
        public RentalCar PutRentalCar(int id, [FromBody] RentalCar value)
        {
            return _dbManager.UpdateRentalCar(id, value);
        }

        [HttpGet("{id}")]
        public ActionResult GetRentalCarById(int id)
        {
            RentalCar rentalCar = _dbManager.GetRentalCarById(id);

            if (rentalCar == null)
            {
                return NotFound("No car with this id: " + id);
            }
            return Ok(rentalCar);
        }

        [HttpPost]
        public ActionResult<RentalCar> PostRentalCar([FromBody] RentalCar newRentalCar)
        {
            RentalCar createdRentalCar = _dbManager.AddRentalCar(newRentalCar);
            return Ok(createdRentalCar);
        }






    }
}
