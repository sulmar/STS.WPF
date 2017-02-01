using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models.Validators
{
    public class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty();

            RuleFor(p => p.LastName)
                .NotEmpty();

            RuleFor(p => p.Birthday)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("Data urodzenia nie może być wcześniejsza niż dzień dzisiejszy");

        }
    }
}
