using CarShareRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShareRestApi.Manager
{
    public class CarDBManager
    {
        private readonly CorolabPraktikDBContext _corolabContext;

        //Vi initialiserer vores DBContext klasse.
        public CarDBManager(CorolabPraktikDBContext context)
        {
            _corolabContext = context;
        }

        //Vi henter en liste af Accounts
        public IEnumerable<Account> GetAllAccounts()
        {
            using (var context = _corolabContext)
            {
                var accounts = context.Accounts.ToList();
                return accounts;
            }
        }

        //Vi henter den fulde liste af biler. Her bruger vi using (var context) for kun at hente listen med biler
        public IEnumerable<Car> GetAllCars()
        {
            using (var context = _corolabContext)
            {
                var car = context.Cars.ToList();
                return car;
            }
        }
        //Vi finder en specifik account ud fra accountets id
        public Account GetAccountById(int id)
        {
            return _corolabContext.Accounts.Find(id);
        }

        //Vi finder en specifik bil ud fra bilens id
        public Car GetCarById(int id)
        {
            return _corolabContext.Cars.Find(id);
        }

        //Her tilføjer vi en ny account til vores database tabel. Værdierne til hvad Account indeholder er i vores Account.cs klasse i model folderen.
        public Account AddAccount(Account addAccount)
        {
            using (var context = _corolabContext)
            {
                var accounts = context.Accounts.Add(addAccount);
                _corolabContext.SaveChanges();
                return addAccount;
            }
        }

        //Her fjerner vi et Account ud fra Account.Id, dette er en sikker måde at slette en specifik account, da primary key altid er unik.
        public Account DeleteAccount(int id)
        {
            Account account = _corolabContext.Accounts.Find(id);
           // Car car = _corolabContext.Cars.Find(id);
            _corolabContext.Accounts.Remove(account);
            _corolabContext.SaveChanges();
            return account;
        }

        //Her fjerner vi en Car ud fra Car.Id, dette er en sikker måde at slette en specifik account, da primary key altid er unik.
        public Car DeleteCar(int id)
        {
            Car car = _corolabContext.Cars.Find(id);
            _corolabContext.Cars.Remove(car);
            _corolabContext.SaveChanges();
            return car;
        }

        //Vi opdaterer Account og dens værdier, Account.Id kan ikke ændres, da det er primary key og skal være unik.
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

        //Vi opdaterer Car og dens værdier, vi kan ikke opdatere Car.Id, da det er primary key. Det samme gælder for Account.Id, da en primary key skal være unik.
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
    }
}
