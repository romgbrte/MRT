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
    public class StatesCoveredApiTests
    {
        Mock<IStateCoverageDtoService> mStateCoverageDtoService;
        List<StateDto> stateDtos;
        List<StateCoverageDto> stateCoverageDtos;
        List<StateCoverageDto> stateCoverageDtosByCarrier;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestInitialize]
        public void TestInit()
        {
            mStateCoverageDtoService = new Mock<IStateCoverageDtoService>();

            stateDtos = new List<StateDto>()
            {
                new StateDto { Id = 1, Name = "Alabama", Abbreviation = "AL" },
                new StateDto { Id = 2, Name = "Georgia", Abbreviation = "GA" },
                new StateDto { Id = 3, Name = "Texas", Abbreviation = "TX" }
            };

            stateCoverageDtos = new List<StateCoverageDto>()
            {
                new StateCoverageDto { Id = 1, CarrierId = 1, StateId = 1, State = stateDtos[0] },
                new StateCoverageDto { Id = 2, CarrierId = 2, StateId = 2, State = stateDtos[1] },
                new StateCoverageDto { Id = 3, CarrierId = 3, StateId = 3, State = stateDtos[2] }
            };
            mStateCoverageDtoService.Setup(m => m.GetListOfStateCoverageDtosAsync()).ReturnsAsync(stateCoverageDtos);
            stateCoverageDtosByCarrier = new List<StateCoverageDto>()
            {
                new StateCoverageDto { Id = 1, CarrierId = 2, StateId = 1, State = stateDtos[0] },
                new StateCoverageDto { Id = 2, CarrierId = 2, StateId = 2, State = stateDtos[1] },
                new StateCoverageDto { Id = 3, CarrierId = 2, StateId = 3, State = stateDtos[2] }
            };
            mStateCoverageDtoService
                .Setup(m => m.GetListOfStateCoverageDtosByCarrierAsync(It.Is<int>(i => i == 2)))
                .ReturnsAsync(stateCoverageDtosByCarrier);
            mStateCoverageDtoService
                .Setup(m => m.GetStateCoverageByCarrierAndStateAsync(It.Is<int>(i => i == 2), It.Is<int>(i => i == 2)))
                .ReturnsAsync(stateCoverageDtosByCarrier[1]);
            mStateCoverageDtoService.Setup(m => m.AddStateCoverage(It.IsAny<StateCoverageDto>()));
            mStateCoverageDtoService.Setup(m => m.RemoveStateCoverage(It.IsAny<StateCoverageDto>()));
            mStateCoverageDtoService.Setup(m => m.SaveStateCoverageChangesAsync()).ReturnsAsync(1);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public async Task GetStatesCovered_RequestListOfStates_ReturnListOfStateDtos()
        {
            // Arrange
            var apiController = new StatesCoveredController(mStateCoverageDtoService.Object);
            int carrierId = 2;

            // Act
            var result = await apiController.GetStatesCovered(carrierId);
            var resultContent = result as OkNegotiatedContentResult<List<StateDto>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, resultContent.Content.Count);
        }

        [TestMethod]
        public async Task CreateStateCoverage_AddNewStateCoverageRecord_SaveChangesAndReturnOkStatus()
        {
            // Arrange
            var apiController = new StatesCoveredController(mStateCoverageDtoService.Object);
            var stateDto = new StateDto { Id = 1, Name = "Alabama", Abbreviation = "AL" };
            var stateCoverageDto = new StateCoverageDto { Id = 1, CarrierId = 1, StateId = 1, State = stateDto };

            // Act
            var result = await apiController.CreateStateCoverage(stateCoverageDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteStateCoverage_RemoveExistingStateCoverageRecord_SaveChangesAndReturnOkStatus()
        {
            // Arrange
            var apiController = new StatesCoveredController(mStateCoverageDtoService.Object);
            var stateDto = new StateDto { Id = 2, Name = "Georgia", Abbreviation = "GA" };
            var stateCoverageDto = new StateCoverageDto { Id = 2, CarrierId = 2, StateId = 2, State = stateDto };

            // Act
            var result = await apiController.DeleteStateCoverage(stateCoverageDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
