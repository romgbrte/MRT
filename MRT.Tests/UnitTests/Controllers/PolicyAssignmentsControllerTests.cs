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
    public class PolicyAssignmentsControllerTests
    {
        private Mock<IPolicyService> mPolicyService;
        private Mock<IPolicyTypeService> mPolicyTypeService;
        private Mock<ICarrierService> mCarrierService;
        private Mock<IPolicyAssignmentService> mPolicyAssignmentService;
        private List<Policy> policies;
        private List<PolicyType> policyTypes;
        private List<Carrier> carriers;
        private List<PolicyAssignment> policyAssignments;

        [TestInitialize]
        public void Initialize()
        {
            mPolicyService = new Mock<IPolicyService>();
            mPolicyTypeService = new Mock<IPolicyTypeService>();
            mCarrierService = new Mock<ICarrierService>();
            mPolicyAssignmentService = new Mock<IPolicyAssignmentService>();

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

            carriers = new List<Carrier>()
            {
                new Carrier { Id = 1, Name = "Carrier One", BaseRate = 1.11f },
                new Carrier { Id = 2, Name = "Carrier Two", BaseRate = 2.22f },
                new Carrier { Id = 3, Name = "Carrier Three", BaseRate = 3.33f }
            };
            mCarrierService.Setup(m => m.GetCarrierListAsync()).ReturnsAsync(carriers);
            mCarrierService.Setup(m => m.GetSingleCarrierAsync(It.IsAny<int>())).ReturnsAsync(carriers[0]);
            mCarrierService.Setup(m => m.AddCarrier(It.IsAny<Carrier>()));
            mCarrierService.Setup(m => m.SaveCarrierChangesAsync()).ReturnsAsync(1);

            policyAssignments = new List<PolicyAssignment>()
            {
                new PolicyAssignment { Id = 1, CarrierId = 1, Carrier = carriers[0], PolicyId = 1, Policy = policies[0], IsActive = true },
                new PolicyAssignment { Id = 2, CarrierId = 2, Carrier = carriers[1], PolicyId = 2, Policy = policies[1], IsActive = true },
                new PolicyAssignment { Id = 3, CarrierId = 3, Carrier = carriers[2], PolicyId = 3, Policy = policies[2], IsActive = true }
            };
            mPolicyAssignmentService.Setup(m => m.GetSingleActivePolicyAssignmentAsync(It.IsAny<int>())).ReturnsAsync(policyAssignments[0]);
            mPolicyAssignmentService.Setup(m => m.AddPolicyAssignment(It.IsAny<PolicyAssignment>()));
            mPolicyAssignmentService.Setup(m => m.SavePolicyAssignmentChangesAsync()).ReturnsAsync(1);
        }

        [TestMethod]
        public async Task Create_RequestPolicyAssignmentFormView_ReturnNewPolicyAssignmentFormViewModel()
        {
            // Arrange
            var controller = new PolicyAssignmentsController(mPolicyService.Object, 
                mPolicyTypeService.Object, mCarrierService.Object, mPolicyAssignmentService.Object);

            // Act
            int policyId = 1;
            var result = await controller.Create(policyId) as ViewResult;
            var model = (PolicyAssignmentViewModel)result.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, model.Id);
        }

        [TestMethod]
        public async Task Save_SaveChangesToDataDbContext_RedirectToPoliciesIndex()
        {
            // Arrange
            var controller = new PolicyAssignmentsController(mPolicyService.Object,
                mPolicyTypeService.Object, mCarrierService.Object, mPolicyAssignmentService.Object);

            // Act
            var result = await controller.Save(policyAssignments[0]) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["controller"], "Policies");
        }
    }
}
