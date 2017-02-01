using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{

    // PM> Install-Package PropertyChanged.Fody

    [ImplementPropertyChanged]
    public class Driver : Base, IDataErrorInfo
    {
        public int DriverId { get; set; }

        private string _FistName;

        public string FirstName
        {
            get { return _FistName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Imię jest puste");

                _FistName = value;

            }
        }



        public string LastName { get; set; }

        public string Phone { get; set; }

        public string NumberId { get; set; }

        public DateTime Birthday { get; set; }

        public int Weight { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                String errorMessage = String.Empty;
                switch (columnName)
                {
                    case nameof(FirstName):
                        if (String.IsNullOrEmpty(FirstName))
                        {
                            errorMessage = "First Name is required";
                        }
                        break;
                    case nameof(LastName):
                        if (String.IsNullOrEmpty(LastName))
                        {
                            errorMessage = "Nazwisko jest wymagane";
                        }
                        break;
                }
                return errorMessage;
            }
        }

        public override string ToString() => FullName;
    }
}
