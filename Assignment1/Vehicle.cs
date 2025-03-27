namespace VehicleManagement
{
    // Enum to represent the type of car
    public enum VehicleType
    {
        Electric,
        Fuel,
        Hybrid
    }
    abstract class Vehicle
    {
        // Properties of the Vehicle class
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public VehicleType VehicleType { get; set; }
        // Constructor with default parameter values
        public Vehicle(string make = "Unknown", string model = "Unknown", int year = 2000, VehicleType vehicleType = VehicleType.Electric)
        {
            Make = make;
            Model = model;
            Year = year;
            VehicleType = vehicleType;
        }
        // Method
        public abstract void DisplayInfo();
    }
    // Class to represent a Car
    class Car(string make, string model, int year, VehicleType vehicleType) : Vehicle(make, model, year, vehicleType)
    {

        // Method override from Vehicle class
        public override void DisplayInfo()
        {
            Console.WriteLine($"{VehicleType} Car {Make} {Model}, Year: {Year}");
        }
    }
    // Class to represent a MotorBike
    class MotorBike(string make, string model, int year, VehicleType vehicleType) : Vehicle(make, model, year, vehicleType)
    {
        // Method override from Vehicle class
        public override void DisplayInfo()
        {
            Console.WriteLine($"{VehicleType} MotorBike {Make} {Model}, Year: {Year}");
        }
    }
}
