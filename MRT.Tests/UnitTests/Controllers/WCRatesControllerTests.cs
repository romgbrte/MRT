﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRT.Controllers;

namespace MRT.Tests.UnitTests.Controllers
{
    [TestClass]
    public class WCRatesControllerTests
    {
        [TestMethod]
        public void Index_RequestIndexView_ReturnIndexView()
        {
            // Arrange
            var controller = new WCRatesController();

            // Act
            var result = controller.Index() as ViewResult;
            var viewName = result.ViewName;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", viewName);
        }
    }
}
