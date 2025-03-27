namespace Assignment2
{
    // abstract class Car
    abstract class Car
    {
        // Properties of Car Class
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        // Constructor
        public Car(string make, string model, int year, DateTime lastMaintenanceDate)
        {
            Make = make;
            Model = model;
            Year = year;
            LastMaintenanceDate = lastMaintenanceDate;
        }

        // Method to display car information
        public abstract void DisplayInfo();
        // Method to schedule maintenance
        public DateTime ScheduleMaintenance()
        {
            return LastMaintenanceDate.AddMonths(6);
        }
    }
    // Interface for Fuelable
    interface IFuelable
    {
        public void Refuel(DateTime timeOfRefuel);
    }
    // Interface for Chargable
    interface IChargable
    {
        public void Charge(DateTime timeOfCharge);
    }
    // FuelCar class
    class FuelCar(string make, string model, int year, DateTime lastMaintenanceDate) : Car(make, model, year, lastMaintenanceDate), IFuelable
    {
        // Method to Refuel implemented from IFuelable interface
        public void Refuel(DateTime timeOfRefuel)
        {
            Console.WriteLine($"FuelCar {Make} {Model} refueled on {timeOfRefuel.ToString("yyyy-MM-dd HH:mm")}");


        }
        // Method to display car information
        public override void DisplayInfo()
        {
            Console.WriteLine($"Fuel Car: {Make} {Model}, Year: ({Year})");
            Console.WriteLine($"Last Maintenance: {LastMaintenanceDate.ToString("dd-MM-yyyy HH:mm")}");
            Console.WriteLine($"Next Maintenance: {this.ScheduleMaintenance().ToString("dd-MM-yyyy HH:mm")}");
        }
    }
    // ElectricCar class
    class ElectricCar(string make, string model, int year, DateTime lastMaintenanceDate) : Car(make, model, year, lastMaintenanceDate), IChargable
    {
        // Method to Charge implemented from IChargable interface
        public void Charge(DateTime timeOfCharge)
        {
            Console.WriteLine($"ElectricCar {Make} {Model} charged on {timeOfCharge.ToString("yyyy-MM-dd HH:mm")}");
        }
        // Method to display car information
        public override void DisplayInfo()
        {
            Console.WriteLine($"Electric Car: {Make} {Model} ({Year})");
            Console.WriteLine($"Last Maintenance: {LastMaintenanceDate.ToString("dd-MM-yyyy")}");
            Console.WriteLine($"Next Maintenance: {this.ScheduleMaintenance().ToString("dd-MM-yyyy")}");
        }
    }
}
