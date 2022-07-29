﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Modelos
{
    public class Request
    {
        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }
    }
}
