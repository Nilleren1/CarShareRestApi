namespace CarShareRestApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int NumOfSeats { get; set; }
        public string FuelType { get; set; }



        public Car(string model, string brand, double price, int numOfSeats, string fuelType)
        {
            Model = model;
            Brand = brand;
            Price = price;
            NumOfSeats = numOfSeats;
            FuelType = fuelType;
        }
        public Car()
        {

        }

        public override string ToString()
        {
            return $"Model: {Model}, Brand: {Brand}, Price: {Price}, Number of seats: {NumOfSeats}: Type of fuel: {FuelType}";
        }
    }
}
