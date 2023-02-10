using CarShareRestApi.Manager;
using CarShareRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Microsoft.AspNetCore.Components;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;

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
        [Route("/Account")]
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
        [Route("/Car")]
        public ActionResult<List<Car>> GetAllCars()
        {
            IEnumerable<Car> cars = _dbManager.GetAllCars();

            if (!cars.Any())
            {
                return NotFound("No cars here");
            }
            return Ok(cars);
        }

        //Update Account from id
        [HttpPut]
        [Route("/PutAccountByID")]
        public Account PutAccount(int id, [FromBody] Account value)
        {
            if(value == null)
            {
                NotFound("no account with this id");
            }
            return _dbManager.UpdateAccount(id, value);  
        }

        [HttpPut]
        [Route("/GetCarByID")]
        public Car PutCar(int id, [FromBody] Car value)
        {
            return _dbManager.UpdateCar(id, value);
        }

        //[HttpGet("{id}")]
        //public ActionResult GetAccountById(int id)
        //{
        //    Account account = _dbManager.GetAccountById(id);

        //    if (account == null)
        //    {
        //        return NotFound("No account with this id: " + id);
        //    }
        //    return Ok(account);
        //}

        [HttpPost]
        [Route("/AccountPost")]
        public ActionResult<Account> PostAccount([FromBody] Account newAccount)
        {
            Account createdAccount = _dbManager.AddAccount(newAccount);
            return Ok(createdAccount);
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





    }
}
