using System;
using System.Collections.Generic;

namespace CarsCapstone.Models
{
    public partial class CarInfo
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
    }
}
