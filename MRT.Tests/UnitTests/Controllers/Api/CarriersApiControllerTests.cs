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
    public class CarriersApiControllerTests
    {
        private Mock<ICarrierDtoService> mCarrierDtoService;
        private Mock<IStateDtoService> mStateDtoService;
        private Mock<IStateCoverageDtoService> mStateCoverageDtoService;
        private List<CarrierDto> carrierDtos;
        private List<StateDto> stateDtos;
        private List<StateCoverageDto> stateCoverageDtos;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestInitialize]
        public void TestInit()
        {
            mCarrierDtoService = new Mock<ICarrierDtoService>();
            mStateDtoService = new Mock<IStateDtoService>();
            mStateCoverageDtoService = new Mock<IStateCoverageDtoService>();

            carrierDtos = new List<CarrierDto>()
            {
                new CarrierDto { Id = 1, Name = "Carrier One", BaseRate = 1.11f },
                new CarrierDto { Id = 2, Name = "Carrier Two", BaseRate = 2.22f },
                new CarrierDto { Id = 3, Name = "Carrier Three", BaseRate = 3.33f }
            };
            mCarrierDtoService.Setup(m => m.GetCarrierDtoListAsync()).ReturnsAsync(carrierDtos);

            stateDtos = new List<StateDto>()
            {
                new StateDto { Id = 1, Name = "Alabama", Abbreviation = "AL" },
                new StateDto { Id = 2, Name = "Georgia", Abbreviation = "GA" },
                new StateDto { Id = 3, Name = "Texas", Abbreviation = "TX" }
            };
            mStateDtoService.Setup(m => m.GetListOfStateDtosAsync()).ReturnsAsync(stateDtos);

            stateCoverageDtos = new List<StateCoverageDto>()
            {
                new StateCoverageDto { Id = 1, CarrierId = 1, StateId = 1, State = stateDtos[0] },
                new StateCoverageDto { Id = 2, CarrierId = 2, StateId = 2, State = stateDtos[1] },
                new StateCoverageDto { Id = 3, CarrierId = 3, StateId = 3, State = stateDtos[2] }
            };
            mStateCoverageDtoService.Setup(m => m.GetListOfStateCoverageDtosAsync()).ReturnsAsync(stateCoverageDtos);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        // Method_Scenario_ExpectedBehavior
        public async Task GetCarriers_RequestListOfCarriers_ReturnListOfCarrierDtos()
        {
            // Arrange
            var apiController = new CarriersController(mCarrierDtoService.Object, 
                mStateDtoService.Object, mStateCoverageDtoService.Object);

            // Act
            var result = await apiController.GetCarriers();
            var resultContent = result as OkNegotiatedContentResult<List<CarrierDto>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, resultContent.Content.Count);
        }
    }
}
