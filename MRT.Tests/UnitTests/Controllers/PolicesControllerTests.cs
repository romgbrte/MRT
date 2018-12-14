using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRT.Controllers;
using MRT.Models;
using MRT.ViewModels;
using MRT.Services.Interfaces;
using Moq;

namespace MRT.Tests.UnitTests.Controllers
{
    [TestClass]
    public class PolicesControllerTests
    {
        private Mock<IPolicyService> mPolicyService;
        private Mock<IPolicyTypeService> mPolicyTypeService;
        private List<Policy> policies;
        private List<PolicyType> policyTypes;

        [TestInitialize]
        public void Initialize()
        {
            mPolicyService = new Mock<IPolicyService>();
            mPolicyTypeService = new Mock<IPolicyTypeService>();

            policyTypes = new List<PolicyType>()
            {
                new PolicyType { Id = 1, Name = "Type 1" },
                new PolicyType { Id = 2, Name = "Type 2" },
                new PolicyType { Id = 3, Name = "Type 3" }
            };
            mPolicyTypeService.Setup(m => m.GetPolicyTypeListAsync()).ReturnsAsync(policyTypes);

            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            policies = new List<Policy>()
            {
                new Policy { Id = 1, Number = "111-11-1111", StartDate = today, EndDate = tomorrow, PolicyTypeId = 1,
                    PolicyType = policyTypes[0], CollateralRate = 1.11f, FundingRate = 1.11f, LossRate = 1.11f },
                new Policy { Id = 2, Number = "222-22-2222", StartDate = today, EndDate = tomorrow, PolicyTypeId = 2,
                    PolicyType = policyTypes[1], CollateralRate = 2.22f, FundingRate = 2.22f, LossRate = 2.22f },
                new Policy { Id = 3, Number = "333-33-3333", StartDate = today, EndDate = tomorrow, PolicyTypeId = 3,
                    PolicyType = policyTypes[2], CollateralRate = 3.33f, FundingRate = 3.33f, LossRate = 3.33f }
            };
            mPolicyService.Setup(m => m.GetSinglePolicyAsync(It.IsAny<int>())).ReturnsAsync(policies[0]);
            mPolicyService.Setup(m => m.AddPolicy(It.IsAny<Policy>()));
            mPolicyService.Setup(m => m.SavePolicyChangesAsync()).ReturnsAsync(1);
        }
        
        [TestMethod]
        public void Index_RequestIndexView_ReturnIndexView()
        {
            // Arrange
            var controller = new PoliciesController();

            // Act
            var result = controller.Index() as ViewResult;
            var viewName = result.ViewName;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", viewName);
        }

        [TestMethod]
        public async Task New_RequestPolicyFormView_ReturnEmptyPolicyFormViewModel()
        {
            // Arrange
            var controller = new PoliciesController(mPolicyService.Object, mPolicyTypeService.Object);

            // Act
            var result = await controller.New() as ViewResult;
            var model = (PolicyFormViewModel)result.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, model.Id);
        }

        [TestMethod]
        public async Task Edit_RequestPolicyById_ReturnPopulatedPolicyFormViewModel()
        {
            // Arrange
            var controller = new PoliciesController(mPolicyService.Object, mPolicyTypeService.Object);

            // Act
            int policyId = 1;
            var result = await controller.Edit(policyId) as ViewResult;
            var model = (PolicyFormViewModel)result.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(policyId, model.Id);
        }

        [TestMethod]
        public async Task Save_SaveChangesToDataDbContext_RedirectToPoliciesIndex()
        {
            // Arrange
            var controller = new PoliciesController(mPolicyService.Object, mPolicyTypeService.Object);

            // Act
            var policyFormViewModel = new PolicyFormViewModel(policies[0]);
            var result = await controller.Save(policyFormViewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["controller"], "Policies");
        }
    }
}
