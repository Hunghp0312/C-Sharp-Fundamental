using Assignment2;
using System.Globalization;
// Main Program
class Program
{

    static void Main()
    {
        AddCar();

    }
    // Function to Add Car
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
            DateTimeStyles.None, out lastMaintenanceDate) || lastMaintenanceDate.Year < year || lastMaintenanceDate > DateTime.Now)
            {
                Console.WriteLine($"Invalid date format! Please enter a valid date (YYYY-MM-dd) between {year} and now");
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
        Car newCar = carType == 'F' ? new FuelCar(make, model, year, lastMaintenanceDate) : new ElectricCar(make, model, year, lastMaintenanceDate); ;
        newCar.DisplayInfo();
        Console.WriteLine();
        char choice;
        // Refuel/Charge Car or not
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
        // Return if dont want to Refuel/Charge
        if (choice == 'N')
        {
            return;
        }
        // Enter Refuel/Charge Date
        while (true)
        {
            Console.Write("Enter refuel/charge date and time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime time) || time.Year < year || time > DateTime.Now)
            {
                Console.WriteLine($"Invalid date format! Please enter a valid date and time between {year} and now");
                continue;
            }
            if (newCar is FuelCar)
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

}