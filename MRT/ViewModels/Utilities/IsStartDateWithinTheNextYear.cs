using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRT.Models;

namespace MRT.ViewModels.Utilities
{
    public class IsStartDateWithinTheNextYear : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var policy = (Policy)validationContext.ObjectInstance;

            if (policy.StartDate == null)
                return new ValidationResult("Start Date is required");

            if (DateTime.Compare(policy.StartDate, DateTime.Today) < 0)
                return new ValidationResult("Start Date cannot be in the past");
            else if (DateTime.Compare(policy.StartDate, DateTime.Today.AddYears(1)) >= 0)
                return new ValidationResult("Start Date must be within a year of today");

            return ValidationResult.Success;
        }
    }
}