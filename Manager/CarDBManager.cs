using CarShareRestApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarShareRestApi.Manager
{
    public class CarDBManager
    {
        private readonly CorolabPraktikDBContext _corolabContext;

        public CarDBManager(CorolabPraktikDBContext context)
        {
            _corolabContext = context;
        }
        
        //Rental Cars CRUD Metoder
        //Rental Cars Get All
        public IEnumerable<Account> GetAllAccounts()
        {
            using (var context = _corolabContext)
            {
                var accounts = context.Accounts.ToList();
                return accounts;
            }

            //List<Account> result = new List<Account>(_corolabContext.Accounts);
            //return result.ToList();
        }
        //Rental Car Get By ID
        public Account GetAccountById(int id)
        {
            return _corolabContext.Accounts.Find(id);
        }

        //Rental Car Add
        public Account AddAccount(Account addAccount)
        {
            using (var context = _corolabContext)
            {
                //var accounts = context.Accounts.Add(addAccount);
                _corolabContext.SaveChanges();
                return addAccount;
            }
            //_corolabContext.Accounts.Add(addAccount);
            //_corolabContext.SaveChanges();
            //return addAccount;
        }

        //Rental Car Delete
        public Account DeleteAccount(int id)
        {
            Account account = _corolabContext.Accounts.Find(id);
            _corolabContext.Accounts.Remove(account);
            _corolabContext.SaveChanges();
            return account;
        }

        //Rental Car Update
        public Account UpdateAccount(int id, Account updates)
        {
            Account account = _corolabContext.Accounts.Find(id);
            account.AccountId = updates.AccountId;
            account.UserName = updates.UserName;
            account.DateOfBirth = updates.DateOfBirth;
            account.UserAddress = updates.UserAddress;
            account.Phone = updates.Phone;
            account.Email = updates.Email;
            _corolabContext.SaveChanges();
            return account;
        }

        //Carpooling CRUD Metoder
        //Carpool Get All
        //public List<CarPooling> GetAllCarPools()
        //{
        //    List<CarPooling> result = new List<CarPooling>(_corolabContext.CarPoolings);

        //    return result.ToList();
        //}

        ////Carpool Get By ID
        //public CarPooling GetCarPoolById(int id)
        //{
        //    return _corolabContext.CarPoolings.Find(id);
        //}

        ////Carpool Add Carpool
        //public CarPooling AddCarPool(CarPooling addCarpool)
        //{
        //    addCarpool.CarPoolId = 0;
        //    _corolabContext.CarPoolings.Add(addCarpool);
        //    _corolabContext.SaveChanges();
        //    return addCarpool;
        //}

        ////Carpool Delete
        //public CarPooling DeleteCarPool(int id)
        //{
        //    CarPooling carpool = _corolabContext.CarPoolings.Find(id);
        //    _corolabContext.CarPoolings.Remove(carpool);
        //    _corolabContext.SaveChanges();
        //    return carpool;
        //}

        ////Carpool Update
        //public CarPooling UpdateCarPool(int id, CarPooling updates)
        //{
        //    CarPooling CarPool = _corolabContext.CarPoolings.Find(id);
        //    CarPool.StartDestination = updates.StartDestination;
        //    CarPool.EndDestination = updates.EndDestination;
        //    CarPool.DriveDate = updates.DriveDate;
        //    CarPool.DriveTime = updates.DriveTime;
        //    CarPool.Price = updates.Price;
        //    CarPool.NumberOfSeats = updates.NumberOfSeats;
        //    _corolabContext.SaveChanges();
        //    return CarPool;
        //}
    }
}
