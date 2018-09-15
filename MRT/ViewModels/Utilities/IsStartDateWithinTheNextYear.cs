using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.ViewModels.Utilities
{
    public class IsStartDateWithinTheNextYear : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var policy = (PolicyFormViewModel)validationContext.ObjectInstance;

            if (DateTime.Compare(policy.StartDate, DateTime.Today) < 0)
                return new ValidationResult(ViewModelValidationStrings.StartDateNotBeforeToday);
            else if (DateTime.Compare(policy.StartDate, DateTime.Today.AddYears(1)) >= 0)
                return new ValidationResult(ViewModelValidationStrings.StartDateNotWithinOneYearOfToday);

            return ValidationResult.Success;
        }
    }
}