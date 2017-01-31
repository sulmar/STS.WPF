using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{

    // PM> Install-Package PropertyChanged.Fody

    [ImplementPropertyChanged]
    public class Driver : Base
    {
        public int DriverId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string NumberId { get; set; }

        public DateTime Birthday { get; set; }

        public int Weight { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() => FullName;
    }
}
