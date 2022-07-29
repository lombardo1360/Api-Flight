using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Modelos
{
    public class Transport
    {
        [Required]
        public string FlightCarrier { get; set; }
        [Required]
        public string FlightNumber { get; set; }
    }
}
