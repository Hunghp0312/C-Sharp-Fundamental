using VehicleManagement;
// Main program class
class Program
{
    // List to store vehicles
    static List<Vehicle> vehicles = new List<Vehicle>
    {
        new Car("Toyota", "Corolla", 2021, VehicleType.Fuel),
        new Car("Tesla", "Model S", 2021, VehicleType.Electric),
        new Car("Ford", "Mustang", 2021, VehicleType.Fuel),
        new MotorBike("Ducati", "Panigale V4", 2021, VehicleType.Fuel)
    };

    // Main method
    static void Main()
    {
        while (true)
        {
            // Display menu options
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a Vehicle");
            Console.WriteLine("2. View All Vehicles");
            Console.WriteLine("3. Search Vehicle by Make");
            Console.WriteLine("4. Filter Vehicle by Type");
            Console.WriteLine("5. Remove a Vehicle by Model");
            Console.WriteLine("6. Filter By Vehicle Category");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            // Try to parse the input choice
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
            {
                Console.WriteLine($"Invalid input! Please enter a valid choice.");
                continue;
            }
            // Execute the corresponding method based on user choice
            switch (choice)
            {
                case 1:
                    AddVehicle();
                    break;
                case 2:
                    ViewAllVehicles();
                    break;
                case 3:
                    SearchVehicleByMake();
                    break;
                case 4:
                    FilterVehicleByType();
                    break;
                case 5:
                    RemoveVehicleByModel();
                    break;
                case 6:
                    FilterByVehicleCategory();
                    break;
                case 7:
                    Console.WriteLine("Goodbye!");
                    return;
            }
            Console.WriteLine("**************************************");

        }

    }

    // Method to add a new car
    static void AddVehicle()
    {
        VehicleType vehicleType;
        int year;
        string? vehicleCategory;
        while (true)
        {
            Console.Write("Enter car type (Car/MotorBike): ");
            vehicleCategory = Console.ReadLine();
            if (vehicleCategory != "Car" && vehicleCategory != "MotorBike")
            {
                Console.WriteLine($"Invalid input car type! Please enter Car or MotorBike");
                continue;
            }
            break;
        }
        // Get car type from user
        while (true)
        {
            Console.Write("Enter car type (Fuel/Electric/Hybrid): ");
            if (!Enum.TryParse(Console.ReadLine(), out vehicleType))
            {
                Console.WriteLine($"Invalid input car type! Please enter \"Electric\" or \"Fuel\" or \"Hybrid\"");
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
        Vehicle newVehicle = (vehicleCategory == "Car") ? new Car(make, model, year, vehicleType) : new MotorBike(make, model, year, vehicleType);
        vehicles.Add(newVehicle);
        Console.WriteLine("Vehicle added successfully!");
    }
    // Method to view all vehicles
    static void ViewAllVehicles()
    {
        for (int i = 0; i < vehicles.Count; i++)
        {
            Console.Write($"Vehicle {i + 1}: ");
            vehicles[i].DisplayInfo();
        }
    }
    // Method to search vehicles by make
    static void SearchVehicleByMake()
    {
        Console.Write("Enter make to search: ");
        string? make = Console.ReadLine();
        List<Vehicle> result = [.. vehicles.Where(car => car.Make == make)];
        if (result.Count == 0)
        {
            Console.WriteLine("No car found!");
            return;
        }
        for (int i = 0; i < result.Count; i++)
        {
            Console.Write($"Vehicle {i + 1}: ");
            result[i].DisplayInfo();
        }
    }
    // Method to filter vehicles by type
    static void FilterVehicleByType()
    {
        // Enter Vehicle Type
        VehicleType carType;
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
        // LINQ to query vehicles by type
        List<Vehicle> result = [.. vehicles.Where(car => car.VehicleType == carType)];
        if (result.Count == 0)
        {
            Console.WriteLine("No vehicle found!");
            return;
        }
        for (int i = 0; i < result.Count; i++)
        {
            Console.Write($"Vehicle {i + 1}: ");
            result[i].DisplayInfo();
        }
    }
    // Method to remove a car by model
    static void RemoveVehicleByModel()
    {
        Console.Write("Enter model to remove: ");
        string? model = Console.ReadLine();
        int res = vehicles.RemoveAll(car => car.Model == model);
        if (res == 0)
        {
            Console.WriteLine("No vehicle found!");
            return;
        }
        Console.WriteLine($"Vehicle removed successfully!");
    }

    // Method to filter vehicles category
    static void FilterByVehicleCategory()
    {
        string? vehicleCategory;
        while (true)
        {
            Console.Write("Enter car type (Car/MotorBike): ");
            vehicleCategory = Console.ReadLine();
            if (vehicleCategory != "Car" && vehicleCategory != "MotorBike")
            {
                Console.WriteLine($"Invalid input car type! Please enter Car or MotorBike");
                continue;
            }
            break;
        }
        if (vehicleCategory == "Car")
        {
            // LINQ to query Cars in Vehicle list
            List<Vehicle> result = [.. vehicles.Where(vehicle => vehicle is Car)];
            if (result.Count == 0)
            {
                Console.WriteLine("No car found!");
                return;
            }
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write($"Vehicle {i + 1}: ");
                result[i].DisplayInfo();
            }
        }
        else
        {
            // LINQ to query MotorBikes in Vehicle list
            List<Vehicle> result = [.. vehicles.Where(vehicle => vehicle is MotorBike)];
            if (result.Count == 0)
            {
                Console.WriteLine("No motorbike found!");
                return;
            }
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write($"Vehicle {i + 1}: ");
                result[i].DisplayInfo();
            }
        }
    }
}