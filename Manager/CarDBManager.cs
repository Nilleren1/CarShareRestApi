using CarShareRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        public IEnumerable<Car> GetAllCars()
        {
            using (var context = _corolabContext)
            {
                var car = context.Cars.ToList();
                return car;
            }
        }
        //Account Get By ID
        public Account GetAccountById(int id)
        {
            return _corolabContext.Accounts.Find(id);
        }

        //Car Get By ID
        public Car GetCarById(int id)
        {
            return _corolabContext.Cars.Find(id);
        }

        //Rental Car Add
        public Account AddAccount(Account addAccount)
        {
            using (var context = _corolabContext)
            {
                var accounts = context.Accounts.Add(addAccount);
                _corolabContext.SaveChanges();
                return addAccount;
            }
        }

        public Car AddCar(Car addCar)
        {

            Account account = GetAccountById(addCar.AccountId);
            if (addCar.AccountId == account.AccountId)
            {
                _corolabContext.Add(addCar);
                _corolabContext.SaveChanges();
                return addCar;
            }
            return addCar;

            //using (var context = _corolabContext)
            //{
            //    var cars = context.Cars.Add(addCar);
            //    _corolabContext.SaveChanges();
            //    return addCar;
            //}
        }
        //Rental Car Delete
        public Account DeleteAccount(int id)
        {
            Account account = _corolabContext.Accounts.Find(id);
            Car car = _corolabContext.Cars.Find(id);
            _corolabContext.Accounts.Remove(account);
            _corolabContext.SaveChanges();
            return account;
        }

        public Car DeleteCar(int id)
        {
            Car car = _corolabContext.Cars.Find(id);
            _corolabContext.Cars.Remove(car);
            _corolabContext.SaveChanges();
            return car;
        }

        //Rental Car Update
        public Account UpdateAccount(int id, Account updates)
        {
            Account account = _corolabContext.Accounts.Find(id);
            account.UserName = updates.UserName;
            account.DateOfBirth = updates.DateOfBirth;
            account.UserAddress = updates.UserAddress;
            account.Phone = updates.Phone;
            account.Email = updates.Email;
            _corolabContext.SaveChanges();
            return account;
        }

        public Car UpdateCar(int id, Car updates)
        {
            Car car = _corolabContext.Cars.Find(id);
            car.StartDestination = updates.StartDestination;
            car.EndDestination = updates.EndDestination;
            car.DriveDate = updates.DriveDate;
            car.Price = updates.Price;
            car.AvailableSeats = updates.AvailableSeats;
            car.Brand = updates.Brand;
            car.Model = updates.Model;
            car.FuelType = updates.FuelType;
            car.IsFull = updates.IsFull;
            _corolabContext.SaveChanges();
            return car;
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
