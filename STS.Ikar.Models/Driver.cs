using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{
    public class Driver : Base
    {
        public int DriverId { get; set; }

        #region FirstName

        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        #endregion

        #region LastName

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set {

                _LastName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));

            }
        }

        #endregion


        public string Phone { get; set; }

        public string NumberId { get; set; }

        public DateTime Birthday { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() => FullName;
    }
}
