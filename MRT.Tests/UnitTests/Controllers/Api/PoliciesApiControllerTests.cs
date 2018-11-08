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
    public class PoliciesApiControllerTests
    {
        Mock<IPolicyDtoService> mPolicyDtoService;
        List<PolicyTypeDto> policyTypeDtos;
        List<PolicyDto> policyDtos;
        
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestInitialize]
        public void TestInit()
        {
            mPolicyDtoService = new Mock<IPolicyDtoService>();

            policyTypeDtos = new List<PolicyTypeDto>()
            {
                new PolicyTypeDto { Id = 1, Name = "Type 1" },
                new PolicyTypeDto { Id = 2, Name = "Type 2" },
                new PolicyTypeDto { Id = 3, Name = "Type 3" }
            };

            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);
            policyDtos = new List<PolicyDto>()
            {
                new PolicyDto { Id = 1, Number = "111-11-1111", StartDate = today, EndDate = tomorrow, PolicyTypeId = 1,
                    PolicyType = policyTypeDtos[0], CollateralRate = 1.11f, FundingRate = 1.11f, LossRate = 1.11f },
                new PolicyDto { Id = 2, Number = "222-22-2222", StartDate = today, EndDate = tomorrow, PolicyTypeId = 2,
                    PolicyType = policyTypeDtos[1], CollateralRate = 2.22f, FundingRate = 2.22f, LossRate = 2.22f },
                new PolicyDto { Id = 3, Number = "333-33-3333", StartDate = today, EndDate = tomorrow, PolicyTypeId = 3,
                    PolicyType = policyTypeDtos[2], CollateralRate = 3.33f, FundingRate = 3.33f, LossRate = 3.33f }
            };
            mPolicyDtoService.Setup(m => m.GetPolicyDtoListAsync()).ReturnsAsync(policyDtos);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public async Task GetPolicies_RequestListOfPolicies_ReturnListOfPolicyDtos()
        {
            // Arrange
            var apiController = new PoliciesController(mPolicyDtoService.Object);

            // Act
            var result = await apiController.GetPolicies();
            var contentResult = result as OkNegotiatedContentResult<List<PolicyDto>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, contentResult.Content.Count);
        }
    }
}
