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

        public ActionResult<List<RentalCar>> GetAllRentalCars()
        {
            List<RentalCar> rentalCars = _dbManager.GetAllRentalCars();

            if (!rentalCars.Any())
            {
                return NotFound("No Cars here");
            }
            return Ok(rentalCars);
        }




    }
}
