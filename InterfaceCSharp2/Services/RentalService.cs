using InterfaceCSharp2.Entities;
using System;

namespace InterfaceCSharp2.Services
{
    internal class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        private ITaxService _taxSevice;
        public RentalService(double pricePerHour, double pricePerDay, ITaxService itaxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxSevice = itaxService;
        }

        public void ProcessingInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
     

            double basicPayment = 0.0;
            if(duration.TotalHours <= 12.0 && duration.Days == 0)
            {
                basicPayment = (PricePerHour * Math.Ceiling(duration.TotalHours));
            }
            else
            {
                basicPayment = (PricePerDay * Math.Ceiling(duration.TotalDays));
            }

            carRental.Invoice = new Invoice(basicPayment, _taxSevice.Tax(basicPayment));
        }
    }
}
