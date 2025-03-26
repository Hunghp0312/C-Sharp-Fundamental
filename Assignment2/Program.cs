using Assignment2;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.InteropServices;



// Chương trình chính
class Program
{
    static List<Car> cars = new List<Car> { new FuelCar("Toyota", "Corolla", 2021, DateTime.Parse("2014-03-25")), new FuelCar("Tesla", "Model S", 2021, DateTime.Parse("2014-03-25")), new ElectricCar("Ford", "Mustang", 2021, DateTime.Parse("2014-03-25")) };

    static void Main()
    {
        //while (true)
        //{
        //    Console.WriteLine("Menu:");
        //    Console.WriteLine("1. Add a Car");
        //    Console.WriteLine("2. View All Cars");
        //    Console.WriteLine("3. Search Car by Make");
        //    Console.WriteLine("4. Filter Car by Type");
        //    Console.WriteLine("5. Remove a Car by Model");
        //    Console.WriteLine("6. Exit");
        //    Console.Write("Enter your choice: ");
        //    // Try to parse the input
        //    if (!int.TryParse(Console.ReadLine(), out int choice))
        //    {
        //        Console.WriteLine($"Invalid input! Please enter a valid integer.");
        //        continue;
        //    }
        //    switch (choice)
        //    {
        //        case 1:
        //            AddCar();
        //            break;
        //        case 2:
        //            ViewAllCars();
        //            break;
        //        case 3:
        //            SearchCarByMake();
        //            break;
        //        case 4:
        //            FilterCarByType();
        //            break;
        //        case 5:
        //            RemoveCarByModel();
        //            break;
        //        case 6:
        //            Console.WriteLine("Goodbye!");
        //            return;
        //    }
        //    Console.WriteLine("**************************************");

        //}
        AddCar();

    }
    static void AddCar()
    {
        DateTime lastMaintenanceDate;
        int year;
        
        // Enter Make
        Console.Write("Enter Make: ");
        string make = Console.ReadLine() ?? "Unknown";
        // Enter Model
        Console.Write("Enter Model: ");
        string model = Console.ReadLine() ?? "Unknown";
        Console.WriteLine();
        // Enter Year
        while (true)
        {
            Console.Write("Enter Year: ");
            if (!int.TryParse(Console.ReadLine(), out year) || year < 1886 || year > DateTime.Now.Year)
            {
                Console.WriteLine($"Invalid input year! Please enter a valid year between 1886 and the current year.");
                continue;
            }
            Console.WriteLine();
            break;
        }
        // Enter Last Maintenance Date
        while (true)
        {
            Console.Write("Enter last maintenance date (YYYY-MM-dd): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out lastMaintenanceDate) || lastMaintenanceDate.Year < 1886 || lastMaintenanceDate > DateTime.Now)
            {
                Console.WriteLine($"Invalid date format! Please enter a valid date (YYYY-MM-dd) between 1886 and now");
                continue;
            }
            Console.WriteLine();
            break;
        }
        // Enter car type
        char carType;
        while (true)
        {
            Console.Write("Is this a FuelCar or ElectricCar? (F/E): ");
            if (!char.TryParse(Console.ReadLine(), out carType) || (carType != 'F' && carType != 'E'))
            {
                Console.WriteLine($"Invalid input! Please enter \'F\' for FuelCar or \'E\' for Electric");
                continue;
            }
            Console.WriteLine();
            break;
        }
        Car newCar;
        newCar = carType == 'F' ?(FuelCar) new FuelCar(make, model, year, lastMaintenanceDate) :(ElectricCar) new ElectricCar(make, model, year, lastMaintenanceDate);
        cars.Add(newCar);
        newCar.DisplayInfo();
        char choice;
        while (true)
        {
            Console.Write("Do you want to refuel/charge? (Y/N): ");

            if (!char.TryParse(Console.ReadLine(), out choice) || (choice != 'Y' && choice != 'N'))
            {
                Console.WriteLine("Invalid input! Please enter Y for Yes or N for No");
                continue;
            }
            Console.WriteLine();
            break;
        }
        if (choice == 'N')
        {
            return;
        }
        while (true)
        {
            Console.Write("Enter refuel/charge date and time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime time) || time.Year < 1886 || time > DateTime.Now)
            {
                Console.WriteLine("Invalid date format! Please enter a valid date and time between 1886 and now");
                continue;
            }
            if(newCar is FuelCar)
            {
                ((FuelCar)newCar).Refuel(time);
            }
            else
            {
                ((ElectricCar)newCar).Charge(time);
            }
            return;
        }


    }
    static void ViewAllCars()
    {
        for (int i = 0; i < cars.Count; i++)
        {
            Console.Write($"Car {i + 1}: ");
            cars[i].DisplayInfo();
        }
    }
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
    //static void FilterCarByType()
    //{
    //    CarType carType;
    //    while (true)
    //    {
    //        Console.Write("Enter car type to filter (Fuel/Electric): ");
    //        if (!Enum.TryParse(Console.ReadLine(), out carType))
    //        {
    //            Console.WriteLine($"Invalid input car type! Please enter Electric or Fuel");
    //            continue;
    //        }
    //        break;
    //    }
    //    List<Car> result;
    //    if (carType == CarType.Fuel)
    //    {
    //        result = [.. cars.Where(car => car is FuelCar)];
    //    }
    //    else
    //    {
    //        result = [.. cars.Where(car => car is ElectricCar)];
    //    }
    //    if (result.Count == 0)
    //    {
    //        Console.WriteLine("No car found!");
    //        return;
    //    }
    //    for (int i = 0; i < result.Count; i++)
    //    {
    //        Console.Write($"Car {i + 1}: ");
    //        result[i].DisplayInfo();
    //    }
    //}
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
        Console.WriteLine($"{res} Car removed successfully!");
    }
}