using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using MRT.ViewModels;
using MRT.ViewModels.Utilities;

namespace MRT.Tests.UnitTests.Utilities
{
    [TestClass]
    public class PolicyEndDateValidationTests
    {
        [TestMethod]
        public void IsValid_EndDateNotLaterThanStartDate_ReturnsValidationFailure()
        {
            // Arrange
            var policy = new PolicyFormViewModel()
            {
                Id = 1,
                Number = "testpolicy",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(-6), // EndDate is set to six months before StartDate
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
            Assert.AreEqual(ViewModelValidationStrings.EndDateNotLaterThanStartDate, validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void IsValid_EndDateNotWithinOneYearOfStartDate_ReturnsValidationFailure()
        {
            // Arrange
            var policy = new PolicyFormViewModel()
            {
                Id = 1,
                Number = "testpolicy",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(18), // EndDate is set to eighteen months after StartDate
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
            Assert.AreEqual(ViewModelValidationStrings.EndDateNotWithinOneYearOfStartDate, validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void IsValid_EndDateIsWithinValidRange_ReturnsValidationSuccess()
        {
            // Arrange
            var policy = new PolicyFormViewModel()
            {
                Id = 1,
                Number = "testpolicy",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(6), // EndDate is set to six months after StartDate
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
