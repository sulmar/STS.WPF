using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{
    public class Vehicle : Base
    {
        public int VehicleId { get; set; }

        public Customer Customer { get; set; }

        public string Mark { get; set; }

        public string Model { get; set; }

        public string VIN { get; set; }
    }
}
