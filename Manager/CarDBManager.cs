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
        public List<RentalCar> GetAllRentalCars()
        {
            List<RentalCar> result = new List<RentalCar>(_corolabContext.RentalCars);

            return result.ToList();
        }
        //Rental Car Get By ID
        //public RentalCar GetRentalCarById(int id)
        //{
        //    return _corolabContext.RentalCars.Find(id);
        //}

        ////Rental Car Add
        //public RentalCar AddRentalCar(RentalCar addCar)
        //{
        //    addCar.RentalCarId = 0;
        //    _corolabContext.RentalCars.Add(addCar);
        //    _corolabContext.SaveChanges();
        //    return addCar;
        //}

        ////Rental Car Delete
        //public RentalCar DeleteRentalCar(int id)
        //{
        //    RentalCar rentalCar = _corolabContext.RentalCars.Find(id);
        //    _corolabContext.RentalCars.Remove(rentalCar);
        //    _corolabContext.SaveChanges();
        //    return rentalCar;
        //}

        ////Rental Car Update
        //public RentalCar UpdateRentalCar(int id, RentalCar updates)
        //{
        //    RentalCar rentalCar = _corolabContext.RentalCars.Find(id);
        //    rentalCar.Price = updates.Price;
        //    rentalCar.Brand = updates.Brand;
        //    rentalCar.NumberOfSeats = updates.NumberOfSeats;
        //    rentalCar.FuelType = updates.FuelType;
        //    rentalCar.Model = updates.Model;
        //    _corolabContext.SaveChanges();
        //    return rentalCar;
        //}

        ////Carpooling CRUD Metoder
        ////Carpool Get All
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
