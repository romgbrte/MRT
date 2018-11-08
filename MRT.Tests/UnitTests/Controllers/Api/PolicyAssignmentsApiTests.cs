using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRT.App_Start;
using MRT.Controllers.Api;
using MRT.Dtos;
using MRT.Services.Interfaces;
using Moq;
using AutoMapper;

namespace MRT.Tests.UnitTests.Controllers.Api
{
    [TestClass]
    public class PolicyAssignmentsApiTests
    {
        Mock<IPolicyAssignmentDtoService> mPolicyAssignmentDtoService;
        List<PolicyDto> policyDtos;
        List<CarrierDto> carrierDtos;
        List<PolicyAssignmentDto> policyAssignmentDtos;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestInitialize]
        public void TestInit()
        {
            mPolicyAssignmentDtoService = new Mock<IPolicyAssignmentDtoService>();

            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            policyDtos = new List<PolicyDto>()
            {
                new PolicyDto { Id = 1, Number = "111-11-1111", StartDate = today, EndDate = tomorrow, PolicyTypeId = 1,
                    PolicyType = null, CollateralRate = 1.11f, FundingRate = 1.11f, LossRate = 1.11f },
                new PolicyDto { Id = 2, Number = "222-22-2222", StartDate = today, EndDate = tomorrow, PolicyTypeId = 2,
                    PolicyType = null, CollateralRate = 2.22f, FundingRate = 2.22f, LossRate = 2.22f },
                new PolicyDto { Id = 3, Number = "333-33-3333", StartDate = today, EndDate = tomorrow, PolicyTypeId = 3,
                    PolicyType = null, CollateralRate = 3.33f, FundingRate = 3.33f, LossRate = 3.33f }
            };

            carrierDtos = new List<CarrierDto>()
            {
                new CarrierDto { Id = 1, Name = "Carrier One", BaseRate = 1.11f },
                new CarrierDto { Id = 2, Name = "Carrier Two", BaseRate = 2.22f },
                new CarrierDto { Id = 3, Name = "Carrier Three", BaseRate = 3.33f }
            };

            policyAssignmentDtos = new List<PolicyAssignmentDto>()
            {
                new PolicyAssignmentDto { Id = 1, CarrierId = 1, Carrier = carrierDtos[0], PolicyId = 1, Policy = policyDtos[0], IsActive = true },
                new PolicyAssignmentDto { Id = 2, CarrierId = 2, Carrier = carrierDtos[1], PolicyId = 2, Policy = policyDtos[1], IsActive = true },
                new PolicyAssignmentDto { Id = 3, CarrierId = 3, Carrier = carrierDtos[2], PolicyId = 3, Policy = policyDtos[2], IsActive = true }
            };
            mPolicyAssignmentDtoService.Setup(m => m.GetPolicyAssignmentDtoListAsync()).ReturnsAsync(policyAssignmentDtos);
            mPolicyAssignmentDtoService.Setup(m => m.GetPolicyAssignmentDtoByPolicyAsync(It.IsAny<int>())).ReturnsAsync(policyAssignmentDtos[0]);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public async Task GetPolicyAssignments_RequestListOfPolicyAssignments_ReturnListOfPolicyAssignmentDtos()
        {
            // Arrange
            var apiController = new PolicyAssignmentsController(mPolicyAssignmentDtoService.Object);

            // Act
            var result = await apiController.GetPolicyAssignments();
            var resultContent = result as OkNegotiatedContentResult<List<PolicyAssignmentDto>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, resultContent.Content.Count);
        }

        [TestMethod]
        public async Task GetPolicyAssignment_RequestPolicyAssignmentByPolicy_ReturnPolicyAssignmentDto()
        {
            // Arrange
            var apiController = new PolicyAssignmentsController(mPolicyAssignmentDtoService.Object);

            // Act
            int policyId = 1;
            var result = await apiController.GetPolicyAssignment(policyId);
            var resultContent = result as OkNegotiatedContentResult<PolicyAssignmentDto>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, resultContent.Content.Id);
        }
    }
}
