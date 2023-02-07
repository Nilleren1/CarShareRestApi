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
        public ActionResult<IEnumerable<Account>> GetAllAccounts()
        {
            IEnumerable<Account> accounts = _dbManager.GetAllAccounts();

            if (!accounts.Any())
            {
                return NotFound("No Accounts here");
            }
            return Ok(accounts);
        }

        //Update Rental Car from id
        [HttpPut("{id}")]
        public Account PutAccount(int id, [FromBody] Account value)
        {
            return _dbManager.UpdateAccount(id, value);
        }

        [HttpGet("{id}")]
        public ActionResult GetAccountById(int id)
        {
            Account account = _dbManager.GetAccountById(id);

            if (account == null)
            {
                return NotFound("No account with this id: " + id);
            }
            return Ok(account);
        }

        [HttpPost]
        public ActionResult<Account> PostAccount([FromBody] Account newAccount)
        {
            Account createdAccount = _dbManager.AddAccount(newAccount);
            return Ok(createdAccount);
        }


        [HttpDelete("{id}")]
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
