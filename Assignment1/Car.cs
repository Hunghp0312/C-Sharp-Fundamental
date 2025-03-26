using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement
{
    // Enum to represent the type of car
    public enum CarType
    {
        Electric,
        Fuel
    }
    // Class to represent a Car
    class Car
    {
        // Properties of the Car class
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; } 
        public CarType CarType { get; set; }

        // Constructor with default parameter values
        public Car(string make = "Unknown", string model = "Unknown", int year = 2000, CarType carType = CarType.Electric)
        {
            Make = make;
            Model = model;
            Year = year;
            CarType = carType;
        }
        // Properties of the Car class
        public void DisplayInfo()
        {
            Console.WriteLine($"{CarType} Car {Make} {Model}, Year: {Year}");
        }
    }
}
