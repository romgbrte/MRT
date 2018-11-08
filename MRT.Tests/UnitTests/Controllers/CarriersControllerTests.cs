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
    public class CarriersControllerTests
    {
        private Mock<ICarrierService> mCarrierService;
        private Mock<IStateService> mStateService;
        private Mock<IStateCoverageService> mStateCoverageService;
        private List<Carrier> carriers;
        private List<State> states;
        private List<StateCoverage> stateCoverages;

        [TestInitialize]
        public void Initialize()
        {
            mCarrierService = new Mock<ICarrierService>();
            mStateService = new Mock<IStateService>();
            mStateCoverageService = new Mock<IStateCoverageService>();

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

            states = new List<State>()
            {
                new State { Id = 1, Name = "Alabama", Abbreviation = "AL" },
                new State { Id = 2, Name = "Georgia", Abbreviation = "GA" },
                new State { Id = 3, Name = "Texas", Abbreviation = "TX" }
            };
            mStateService.Setup(m => m.GetListOfStatesAsync()).ReturnsAsync(states);

            stateCoverages = new List<StateCoverage>()
            {
                new StateCoverage { Id = 1, CarrierId = 1, StateId = 1, State = states[0] },
                new StateCoverage { Id = 2, CarrierId = 2, StateId = 2, State = states[1] },
                new StateCoverage { Id = 3, CarrierId = 3, StateId = 3, State = states[2] }
            };
            mStateCoverageService.Setup(m => m.GetListOfStateCoveragesByCarrierAsync(It.IsAny<int>())).ReturnsAsync(stateCoverages);
            mStateCoverageService.Setup(m => m.GetListOfStateCoveragesAsync()).ReturnsAsync(stateCoverages);
        }

        [TestMethod]
        // Method_Scenario_ExpectedBehavior
        public void Index_RequestIndexView_ReturnIndexView()
        {
            // Arrange
            var controller = new CarriersController();

            // Act
            var result = controller.Index() as ViewResult;
            var viewName = result.ViewName;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", viewName);
        }

        
        [TestMethod]
        public async Task New_RequestCarrierFormView_ReturnEmptyCarrierFormViewModel()
        {
            // Arrange
            var controller = new CarriersController(mCarrierService.Object, 
                mStateService.Object, mStateCoverageService.Object);

            // Act
            var result = await controller.New() as ViewResult;
            var model = (CarrierFormViewModel)result.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, model.Id);
            Assert.AreEqual(3, model.StatesNotCovered.Count);
        }
        
        [TestMethod]
        public async Task Edit_RequestCarrierById_ReturnPopulatedCarrierFormViewModel()
        {
            // Arrange
            var controller = new CarriersController(mCarrierService.Object, 
                mStateService.Object, mStateCoverageService.Object);

            // Act
            int carrierId = 1;
            var result = await controller.Edit(carrierId) as ViewResult;
            var model = (CarrierFormViewModel)result.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(carrierId, model.Id);
        }

        [TestMethod]
        public async Task Save_SaveChangesToDataDbContext_RedirectToCarriersIndex()
        {
            // Arrange
            var controller = new CarriersController(mCarrierService.Object, 
                mStateService.Object, mStateCoverageService.Object);

            // Act
            var result = await controller.Save(carriers[0]) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["controller"], "Carriers");
        }
    }
}
