using FluentValidation.Attributes;
using PropertyChanged;
using STS.Ikar.Models.Validators;
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
    [Validator(typeof(DriverValidator))]
    public class Driver : DataErrorInfo
    {
        public int DriverId { get; set; }

        public string FirstName { get; set; }

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
