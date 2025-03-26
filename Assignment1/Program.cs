using CarManagement;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;



// Main program class
class Program
{
    // List to store cars
    static List<Car> cars = new List<Car>
    {
        new Car("Toyota", "Corolla", 2021, CarType.Fuel),
        new Car("Tesla", "Model S", 2021, CarType.Electric),
        new Car("Ford", "Mustang", 2021, CarType.Fuel)
    };

    // Main method
    static void Main()
    {
       


        while (true)
        {
           
            // Display menu options
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a Car");
            Console.WriteLine("2. View All Cars");
            Console.WriteLine("3. Search Car by Make");
            Console.WriteLine("4. Filter Car by Type");
            Console.WriteLine("5. Remove a Car by Model");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            // Try to parse the input choice
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 6)
            {
                Console.WriteLine($"Invalid input! Please enter a valid choice.");
                continue;
            }
            // Execute the corresponding method based on user choice
            switch (choice)
            {
                case 1:
                    AddCar();
                    break;
                case 2:
                    ViewAllCars();
                    break;
                case 3:
                    SearchCarByMake();
                    break;
                case 4:
                    FilterCarByType();
                    break;
                case 5:
                    RemoveCarByModel();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    return;
            }
            Console.WriteLine("**************************************");

        }

    }

    // Method to add a new car
    static void AddCar()
    {
        CarType carType;
        int year;
        // Get car type from user
        while (true)
        {
            Console.Write("Enter car type (Fuel/Electric): ");
            if (!Enum.TryParse(Console.ReadLine(), out carType))
            {
                Console.WriteLine($"Invalid input car type! Please enter Electric or Fuel");
                continue;
            }
            break;
        }
        // Get car make from user
        Console.Write("Enter Make: ");
        string make = Console.ReadLine() ?? "Unknown";
        // Get car model from user
        Console.Write("Enter Model: ");
        string model = Console.ReadLine() ?? "Unknown";
        // Get car year from user
        while (true)
        {
            Console.Write("Enter Year: ");
            if (!int.TryParse(Console.ReadLine(), out year) || year < 1886 || year > DateTime.Now.Year)
            {
                Console.WriteLine($"Invalid input year! Please enter a valid year between 1886 and the current year.");
                continue;
            }
            break;
        }

        // Create a new car object and add it to the list
        Car newCar = new Car(make, model, year, carType);
        cars.Add(newCar);
        Console.WriteLine("Car added successfully!");
    }
    // Method to view all cars
    static void ViewAllCars()
    {
        for (int i = 0; i < cars.Count; i++)
        {
            Console.Write($"Car {i + 1}: ");
            cars[i].DisplayInfo();
        }
    }
    // Method to search cars by make
    static void SearchCarByMake()
    {
        Console.Write("Enter make to search: ");
        string? make = Console.ReadLine();
        List<Car> result = [.. cars.Where(car => car.Make == make)];
        if (result.Count == 0)
        {
            Console.WriteLine("No car found!");
            return;
        }
        for (int i = 0; i < result.Count; i++)
        {
            Console.Write($"Car {i + 1}: ");
            result[i].DisplayInfo();
        }
    }
    // Method to filter cars by type
    static void FilterCarByType()
    {
        // Enter Car Type
        CarType carType;
        while (true)
        {
            Console.Write("Enter car type to filter (Fuel/Electric): ");
            if (!Enum.TryParse(Console.ReadLine(), out carType))
            {
                Console.WriteLine($"Invalid input car type! Please enter Electric or Fuel");
                continue;
            }
            break;
        }
        // LINQ to query cars by type
        List<Car> result = [.. cars.Where(car => car.CarType == carType)];
        if (result.Count == 0)
        {
            Console.WriteLine("No car found!");
            return;
        }
        for (int i = 0; i < result.Count; i++)
        {
            Console.Write($"Car {i + 1}: ");
            result[i].DisplayInfo();
        }
    }
    // Method to remove a car by model
    static void RemoveCarByModel()
    {
        Console.Write("Enter model to remove: ");
        string? model = Console.ReadLine();
        int res = cars.RemoveAll(car => car.Model == model);
        if (res == 0)
        {
            Console.WriteLine("No car found!");
            return;
        }
        Console.WriteLine($"Car removed successfully!");
    }
}