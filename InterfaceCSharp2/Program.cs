using InterfaceCSharp2.Entities;
using InterfaceCSharp2.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCSharp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the rental data");
                Console.Write("Car model : ");
                string carModel = Console.ReadLine();
                Console.Write("Pickup (dd//MM/yyyy hh:mm): ");
                DateTime pickupCar = DateTime.Parse(Console.ReadLine());
                Console.Write("Return (dd//MM/yyyy hh:mm): ");
                DateTime returnCar = DateTime.Parse(Console.ReadLine());

                CarRental carRental = new CarRental(new Vehicle(carModel),pickupCar,returnCar);
                Console.Write("Enter price per hour : ");
                double pricePerHour = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter price per day : ");
                double pricePerDay = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                RentalService rentalService = new RentalService(pricePerHour, pricePerDay);
                rentalService.ProcessingInvoice(carRental);
                
                Console.WriteLine("INVOICE : ");
                Console.WriteLine(carRental.Invoice);
                Console.WriteLine();


                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
