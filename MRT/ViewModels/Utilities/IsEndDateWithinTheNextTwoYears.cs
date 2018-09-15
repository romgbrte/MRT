using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.ViewModels.Utilities
{
    public class IsEndDateWithinTheNextTwoYears : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var policy = (PolicyFormViewModel)validationContext.ObjectInstance;

            if (DateTime.Compare(policy.EndDate, policy.StartDate) <= 0)
                return new ValidationResult(ViewModelValidationStrings.EndDateNotLaterThanStartDate);
            else if (DateTime.Compare(policy.EndDate, policy.StartDate.AddYears(1)) > 0)
                return new ValidationResult(ViewModelValidationStrings.EndDateNotWithinOneYearOfStartDate);

            return ValidationResult.Success;
        }
    }
}