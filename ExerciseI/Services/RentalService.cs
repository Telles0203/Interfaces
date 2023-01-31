using ExerciseI.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseI.Services
{
    class RentalService
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }

        private ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment = (duration.TotalHours <= 12.00) ? basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours) : basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);

            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
