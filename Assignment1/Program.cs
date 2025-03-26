using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

public enum CarType
{
    Electric,
    Fuel
}
class Car(string make, string model, int year, CarType carType)
{
    // Thuộc tính (Properties)
    public string? Make { get; set; } = make;
    public string? Model { get; set; } = model;
    public int Year { get; set; } = year;
    public CarType? CarType { get; set; } = carType;

    // Phương thức (Method)
    public void DisplayInfo()
    {
        Console.WriteLine($"{CarType} Car {Make} {Model}, Year: {Year}");
    }
}

// Chương trình chính
class Program
{
    static List<Car> cars = new List<Car> { new Car("Toyota", "Corolla", 2021, CarType.Fuel), new Car("Tesla", "Model S", 2021, CarType.Electric), new Car("Ford", "Mustang", 2021, CarType.Fuel) };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a Car");
            Console.WriteLine("2. View All Cars");
            Console.WriteLine("3. Search Car by Make");
            Console.WriteLine("4. Filter Car by Type");
            Console.WriteLine("5. Remove a Car by Model");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            // Try to parse the input
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine($"Invalid input! Please enter a valid integer.");
                continue;
            }
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
    static void AddCar()
    {
        CarType carType;
        int year;
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
        Console.Write("Enter Make: ");
        string make = Console.ReadLine() ?? "Unknown";
        Console.Write("Enter Model: ");
        string model = Console.ReadLine() ?? "Unknown";
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


        Car newCar = new Car(make, model, year, carType);
        cars.Add(newCar);
        Console.WriteLine("Car added successfully!");
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
    static void FilterCarByType()
    {
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
    static void RemoveCarByModel()
    {
        Console.Write("Enter model to remove: ");
        string? model = Console.ReadLine();
        int res = cars.RemoveAll(car => car.Model == model);
        if(res == 0)
        {
            Console.WriteLine("No car found!");
            return;
        }
        Console.WriteLine($"{res} Car removed successfully!");
    }
}