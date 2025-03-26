using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    abstract class Car(string make, string model, int year, DateTime lastMaintenanceDate)
    {
        // Thuộc tính (Properties)
        public string? Make { get; set; } = make;
        public string? Model { get; set; } = model;
        public int Year { get; set; } = year;
        public DateTime LastMaintenanceDate { get; set; } = lastMaintenanceDate;

        // Phương thức (Method)
        public abstract void DisplayInfo();
        public DateTime ScheduleMaintenance()
        {
            return LastMaintenanceDate.AddMonths(6);
        }
    }
    interface IFuelable
    {
        public void Refuel(DateTime timeOfRefuel);
    }
    interface IChargable
    {
        public void Charge(DateTime timeOfCharge);
    }
    class FuelCar(string make, string model, int year, DateTime lastMaintenanceDate) : Car(make, model, year, lastMaintenanceDate), IFuelable
    {
        public void Refuel(DateTime timeOfRefuel)
        {
            Console.WriteLine($"FuelCar {Make} {Model} refueled on {timeOfRefuel.ToString("yyyy-MM-dd HH:mm")}");

        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Fuel Car: {Make} {Model}, Year: ({Year})");
            Console.WriteLine($"Last Maintenance: {LastMaintenanceDate.ToString("dd-MM-yyyy HH:mm")}");
            Console.WriteLine($"Next Maintenance: {this.ScheduleMaintenance().ToString("dd-MM-yyyy HH:mm")}");
        }
    }
    class ElectricCar(string make, string model, int year, DateTime lastMaintenanceDate) : Car(make, model, year, lastMaintenanceDate), IChargable
    {
        public void Charge(DateTime timeOfCharge)
        {
            Console.WriteLine($"ElectricCar {Make} {Model} charged on {timeOfCharge.ToString("yyyy-MM-dd HH:mm")}");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Electric Car: {Make} {Model} ({Year})");
            Console.WriteLine($"Last Maintenance: {LastMaintenanceDate.ToString("dd-MM-yyyy")}");
            Console.WriteLine($"Next Maintenance: {this.ScheduleMaintenance().ToString("dd-MM-yyyy")}");
        }
    }
}
