using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Ikar.Models
{
    public abstract class DataErrorInfo : IDataErrorInfo
    {
        private IValidator Validator => new AttributedValidatorFactory().GetValidator(GetType());

        public string this[string columnName] => InputValidation(columnName);

        public string Error => Validator == null ? string.Empty : GetErrors(Validator.Validate(this));

        public bool Validate(params string[] rulesetsToExecute)
        {
            return Validator.Validate(new ValidationContext(this, new PropertyChain(),
                new RulesetValidatorSelector(rulesetsToExecute))).IsValid;
        }

        private string InputValidation(string propertyName)
        {
            var properties = new List<string> { propertyName };

            if (Validator == null) return string.Empty;

            var results = Validator.Validate
                (new ValidationContext(this, new PropertyChain(), new MemberNameValidatorSelector(properties)));

            return GetErrors(results);
        }

        private static string GetErrors(ValidationResult results)
        {
            if (results == null || !results.Errors.Any()) return string.Empty;
            var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
            return errors;
        }


        public bool IsValid => string.IsNullOrEmpty(Error);
    }
}
