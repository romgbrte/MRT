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
    public class CodesApiControllerTests
    {
        Mock<ICodeDtoService> mCodeDtoService;
        List<CodeDto> codeDtos;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestInitialize]
        public void TestInit()
        {
            mCodeDtoService = new Mock<ICodeDtoService>();

            codeDtos = new List<CodeDto>()
            {
                new CodeDto { Id = 1, Number = "1111", JobDescription = "First job description" },
                new CodeDto { Id = 2, Number = "2222", JobDescription = "Second job description" },
                new CodeDto { Id = 3, Number = "3333", JobDescription = "Third job description" }
            };
            mCodeDtoService.Setup(m => m.GetCodeDtoListAsync()).ReturnsAsync(codeDtos);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public async Task GetCodes_RequestListOfCodes_ReturnListOfCodeDtos()
        {
            // Arrange
            var apiController = new CodesController(mCodeDtoService.Object);

            // Act
            var result = await apiController.GetCodes();
            var resultContent = result as OkNegotiatedContentResult<List<CodeDto>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, resultContent.Content.Count);
        }
    }
}
