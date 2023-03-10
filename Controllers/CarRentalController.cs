using CarShareRestApi.Manager;
using CarShareRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using RoutePrefixAttribute = System.Web.Mvc.RoutePrefixAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using System;

namespace CarShareRestApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private readonly CarDBManager _dbManager;

        public CarRentalController(CorolabPraktikDBContext context)
        {
            _dbManager = new CarDBManager(context);
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<List<Account>> GetAll()
        {
            return null;
        }

        [HttpGet]
        [Route("/Accounts")]
        public ActionResult<List<Account>> GetAllAccounts()
        {
            IEnumerable<Account> accounts = _dbManager.GetAllAccounts();

            if (!accounts.Any())
            {
                return NotFound("No accounts here");
            }
            return Ok(accounts);
        }

        [HttpGet]
        [Route("/Cars")]
        public ActionResult<List<Car>> GetAllCars([FromQuery] DateTime? dateTimeFilter)
        {
            IEnumerable<Car> cars = _dbManager.GetAllCars(dateTimeFilter);

            if (!cars.Any())
            {
                return NotFound("No cars here");
            }
            return Ok(cars);
        }

        //Update Account from id
        [HttpPut]
        [Route("/UpdateAccountByID")]
        public Account PutAccount(int id, [FromBody] Account value)
        {
            if (value == null)
            {
                NotFound("no account with this id");
            }
            return _dbManager.UpdateAccount(id, value);
        }

        [HttpPut]
        [Route("/PutCarByID")]
        public Car PutCar(int id, [FromBody] Car value)
        {
            return _dbManager.UpdateCar(id, value);
        }

        [HttpGet]
        [Route("/GetAccountByID")]
        public ActionResult<Account> GetAccountById(int id)
        {
            Account account = _dbManager.GetAccountById(id);

            if (account == null)
            {
                return NotFound("No account with this id: " + id);
            }
            return Ok(account);
        }

        [HttpGet]
        [Route("/GetCarByID")]
        public ActionResult<Car> GetCarById(int id)
        {
            Car car = _dbManager.GetCarById(id);

            if (car == null)
            {
                return NotFound("No car with this id: " + id);
            }
            return Ok(car);
        }


        [HttpPost]
        [Route("/AccountPost")]
        public ActionResult<Account> PostAccount([FromBody] Account newAccount)
        {
            Account createdAccount = _dbManager.AddAccount(newAccount);
            return Ok(createdAccount);
        }

        

        [HttpPost]
        [Route("/CarPost")]
        public ActionResult<Car> PostCar([FromBody] Car newCar)
        {
            Car createdCar = _dbManager.AddCar(newCar);
            return Ok(createdCar);
        }

        [HttpDelete]
        [Route("/AccountDelete")]
        public ActionResult<Account> DeleteAccount(int id)
        {
            Account account = _dbManager.GetAccountById(id);
            if (account == null)
            {
                return NotFound("No account with that id " + id);
            }
            return _dbManager.DeleteAccount(id);
        }

        [HttpDelete]
        [Route("/CarDelete")]
        public ActionResult<Car> DeleteCar(int id)
        {
            Car car = _dbManager.GetCarById(id);
            if(car == null){
                return NotFound("No car with that id " + id);
            }
            return _dbManager.DeleteCar(id);
           
        }

    }
}
