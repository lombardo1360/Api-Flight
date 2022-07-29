using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Modelos
{
    public class Flight
    {
        [Required]
        public string FlightCarrier { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public string DepartureStation { get; set; }

        [Required]
        public string ArrivalStation { get; set; }

        [Required]
        public double Price { get; set; }

       
    }
}
