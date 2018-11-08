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
    public class WCRatesApiTests
    {
        Mock<IWCRateDtoService> mWCRateDtoService;
        List<WCRateDto> wcRateDtos;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestInitialize]
        public void TestInit()
        {
            mWCRateDtoService = new Mock<IWCRateDtoService>();

            DateTime today = DateTime.Today;
            wcRateDtos = new List<WCRateDto>()
            {
                new WCRateDto { Id = 1, CarrierId = 1, CarrierName = "Carrier One", StateId = 1, StateName = "Alabama",
                    CodeId = 1, CodeNumber = "1111", Rate = 1.11f, EffectiveDate = today, IsActive = true },
                new WCRateDto { Id = 2, CarrierId = 2, CarrierName = "Carrier Two", StateId = 2, StateName = "Georgia",
                    CodeId = 2, CodeNumber = "2222", Rate = 2.22f, EffectiveDate = today, IsActive = true },
                new WCRateDto { Id = 3, CarrierId = 3, CarrierName = "Carrier Three", StateId = 3, StateName = "Texas",
                    CodeId = 3, CodeNumber = "3333", Rate = 3.33f, EffectiveDate = today, IsActive = true }
            };
            mWCRateDtoService.Setup(m => m.GetWCRateDtoListAsync()).ReturnsAsync(wcRateDtos);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public async Task GetWCRates_RequestListOfWCRates_ReturnListOfWCRateDtos()
        {
            // Arrange
            var apiController = new WCRatesController(mWCRateDtoService.Object);

            // Act
            var result = await apiController.GetWCRates();
            var resultContent = result as OkNegotiatedContentResult<List<WCRateDto>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, resultContent.Content.Count);
        }
    }
}
