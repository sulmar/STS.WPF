using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{
    public class Address : Base
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}
