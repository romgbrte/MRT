using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using MRT.Tests.Helpers;
using MRT.ViewModels;
using MRT.ViewModels.Utilities;

namespace MRT.Tests.UnitTests.Utilities
{
    [TestClass]
    public class PolicyStartDateValidationTests
    {
        [TestMethod]
        public void IsValid_StartDateNotBeforeToday_ReturnsValidationFailure()
        {
            // Arrange
            var policy = new PolicyFormViewModel()
            {
                Id = 1,
                Number = "testpolicy",
                StartDate = DateTime.Today.AddMonths(-6), // StartDate set to 6 months before today
                EndDate = DateTime.Today.AddMonths(6),
                PolicyTypeId = 1,
                FundingRate = 1.00f,
                CollateralRate = 1.00f,
                LossRate = 1.00f
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var policyValidation = Validator.TryValidateObject(policy, new ValidationContext(policy), validationResults, true);

            // Assert
            Assert.IsFalse(policyValidation, UnitTestValidationStrings.ValidationFailureMessage);
            Assert.AreEqual(1, validationResults.Count, UnitTestValidationStrings.OneValidationErrorExpected);
            Assert.AreEqual(ViewModelValidationStrings.StartDateNotBeforeToday, validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void IsValid_StartDateNotWithinOneYearOfToday_ReturnsValidationFailure()
        {
            // Arrange
            var policy = new PolicyFormViewModel()
            {
                Id = 1,
                Number = "testpolicy",
                StartDate = DateTime.Today.AddMonths(13), // StartDate set to thirteen months after today
                EndDate = DateTime.Today.AddMonths(18),
                PolicyTypeId = 1,
                FundingRate = 1.00f,
                CollateralRate = 1.00f,
                LossRate = 1.00f
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var policyValidation = Validator.TryValidateObject(policy, new ValidationContext(policy), validationResults, true);

            // Assert
            Assert.IsFalse(policyValidation, UnitTestValidationStrings.ValidationFailureMessage);
            Assert.AreEqual(1, validationResults.Count, UnitTestValidationStrings.OneValidationErrorExpected);
            Assert.AreEqual(ViewModelValidationStrings.StartDateNotWithinOneYearOfToday, validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void IsValid_StartDateIsWithinValidRange_ReturnsValidationSuccess()
        {
            // Arrange
            var policy = new PolicyFormViewModel()
            {
                Id = 1,
                Number = "testpolicy",
                StartDate = DateTime.Today.AddMonths(1), // StartDate set to one month from today
                EndDate = DateTime.Today.AddMonths(6),
                PolicyTypeId = 1,
                FundingRate = 1.00f,
                CollateralRate = 1.00f,
                LossRate = 1.00f
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var policyValidation = Validator.TryValidateObject(policy, new ValidationContext(policy), validationResults, true);

            // Assert
            Assert.IsTrue(policyValidation, UnitTestValidationStrings.ValidationSuccessMessage);
            Assert.AreEqual(0, validationResults.Count, UnitTestValidationStrings.NoValidationErrorExpected);
        }
    }
}
