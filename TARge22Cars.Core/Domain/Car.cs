﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge22Cars.Core.Domain
{
    public class Car
    {
        public Guid? CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Power { get; set; }
        public string Transmission { get; set; }
        public string Drivetrain { get; set; }
        public string Fuel { get; set; }
        public int FuelConsumption { get; set; }
        public int Mileage { get; set; }

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
