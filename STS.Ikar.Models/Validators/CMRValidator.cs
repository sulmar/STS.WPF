using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models.Validators
{
    public class CMRValidator : AbstractValidator<CMR>
    {
        public CMRValidator()
        {
            RuleFor(p => p.WarehouseDocuments)
                .Must(p => p.Any());
        }
    }
}
