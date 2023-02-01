using CarShareRestApi.Models;
using System.Collections.Generic;
using System.Drawing;

namespace CarShareRestApi.Manager
{
    public class CarManager
    {
        private static int _nextId = 1;
        
        private static List<Car> carList = new List<Car>()
        {
            new Car() {Id = _nextId++, Model = "CW420", Brand = "Mercedes", Price=600, NumOfSeats = 2, FuelType= "El"},
            new Car() {Id = _nextId++, Model = "Focus", Brand = "Ford", Price=40, NumOfSeats = 5, FuelType= "Gas"},
            new Car() {Id = _nextId++, Model = "Batcar", Brand = "Bat", Price=600, NumOfSeats = 4, FuelType= "Diesel"},

        };

        public List<Car> GetAllCars()
        {
            return carList;
        }

        public Car GetCar(int id)
        {
            return carList.Find(c => c.Id == id);
        }

        public Car AddCar(Car car)
        {
            car.Id = _nextId++;
            carList.Add(car);
            return car;
        }

        public Car DeleteCar(int id)
        {
            Car carToBeDeleted = GetCar(id);
            carList.Remove(carToBeDeleted);
            return carToBeDeleted;
        }
    }
}
