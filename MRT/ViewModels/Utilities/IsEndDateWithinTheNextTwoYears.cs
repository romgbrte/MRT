using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRT.Models;

namespace MRT.ViewModels.Utilities
{
    public class IsEndDateWithinTheNextTwoYears : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var policy = (Policy)validationContext.ObjectInstance;

            if (policy.EndDate == null)
                return new ValidationResult("End Date is required");

            if (DateTime.Compare(policy.EndDate, policy.StartDate) <= 0)
                return new ValidationResult("End Date must be later than the Start Date");
            else if (DateTime.Compare(policy.EndDate, policy.StartDate.AddYears(1)) > 0)
                return new ValidationResult("End Date must be within one year of the Start Date");
            else if (DateTime.Compare(policy.StartDate, DateTime.Today.AddYears(2)) >= 0)
                return new ValidationResult("Start Date must be within two years of today");

            return ValidationResult.Success;
        }
    }
}