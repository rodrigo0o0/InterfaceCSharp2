using System;

namespace InterfaceCSharp2.Entities
{
    internal class CarRental
    {
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public CarRental(Vehicle vehicle, DateTime start, DateTime finish)
        {
            Vehicle = vehicle;
            Start = start;
            Finish = finish;
        }
    }
}
