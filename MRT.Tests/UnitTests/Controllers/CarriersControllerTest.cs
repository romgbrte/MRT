using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRT.Controllers;
using MRT.ViewModels;

namespace MRT.Tests.UnitTests.Controllers
{
    [TestClass]
    public class CarriersControllerTest
    {
        [TestMethod]
        // Method_Scenario_ExpectedBehavior
        public void Index_RequestIndexView_ReturnIndexView()
        {
            // Arrange
            var controller = new CarriersController();

            // Act
            var viewResult = controller.Index() as ViewResult;
            var viewName = viewResult.ViewName;

            // Assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual("Index", viewName);
        }
        /*
        [TestMethod]
        public async Task New_RequestCarrierFormView_ReturnCarrierFormViewWithEmptyViewModel()
        {
            // Arrange
            var controller = new CarriersController();

            // Act
            var viewResult = await controller.New() as ViewResult;
            var viewName = viewResult.ViewName;
            var model = viewResult.Model;

            // Assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual(typeof(CarrierFormViewModel), model);
            Assert.AreEqual("CarrierForm", viewName);
        }
        */
    }
}
