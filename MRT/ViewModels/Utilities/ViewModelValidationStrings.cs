using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.ViewModels.Utilities
{
    public class ViewModelValidationStrings
    {
        public const string ValidationContextNull = 
            "There was a problem submitting the data (instance of validationContext was null)";
        public const string StartDateNotBeforeToday = 
            "Start Date cannot be earlier than today's date";
        public const string StartDateNotWithinOneYearOfToday = 
            "Start Date must be within 1 year of today's date";
        public const string EndDateNotLaterThanStartDate = 
            "End Date must be later than the Start Date";
        public const string EndDateNotWithinOneYearOfStartDate = 
            "End Date must be within one year of the Start Date";
    }
}