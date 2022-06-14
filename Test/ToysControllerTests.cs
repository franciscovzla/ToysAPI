using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Contracts;
using Models;
using ToysAPI.Controllers;
using System.Collections;
using Services.DTO;
namespace Test
{
    public class ToysControllerTests
    {
        private Mock<IToyService> _toysServiceStub = new Mock<IToyService>();
        private Random rand = new();


        [Fact]
        public async Task GetToys()
        {
            // Arrange
            var expectedItems = GenerateRandomObjectForList();

            _toysServiceStub.Setup(service => service.GetToys())
                .ReturnsAsync(expectedItems);
            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.GetToys();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }



        [Fact]
        public async Task UpdateToy_WithValidModelAndId_ReturnsOk()
        {
            // Arrange
            var validModel = GenerateRandomObject(true);

            _toysServiceStub.Setup(service => service.UpdateToy(validModel))
                .ReturnsAsync(true);

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.UpdateToy(validModel);

            // Result
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task UpdateToy_WithNoId_ReturnsNotFound()
        {
            // Arrange
            var invalidModel = GenerateRandomObject(false);

            _toysServiceStub.Setup(service => service.UpdateToy(invalidModel))
                .ReturnsAsync(false);

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.UpdateToy(invalidModel);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task DeleteToy_WithValidModelAndId_ReturnsOk()
        {
            // Arrange
            var validModel = GenerateRandomObject(true);

            _toysServiceStub.Setup(service => service.UpdateToy(validModel))
                .ReturnsAsync(true);

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.UpdateToy(validModel);

            // Result
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task DeleteToy_WithNoId_ReturnsNotFound()
        {
            // Arrange
            var invalidModel = GenerateRandomObject(false);

            _toysServiceStub.Setup(service => service.DeleteToy(invalidModel.Id))
                .ReturnsAsync(false);

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.DeleteToy(invalidModel.Id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }



      
        private ToysDTO GenerateRandomObject(bool returnId) =>
            new()
            {
                Id = returnId == true ? rand.Next(100) : null,
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                AgeRestriction = rand.Next(10),
                CompanyId = rand.Next(10),
                Price = Convert.ToDecimal(rand.NextDouble()),

            };

        private List<ToysViewModel> GenerateRandomObjectForList() =>
            new()
            {
                new()
                {
                    Id = rand.Next(100),
                    Name = Guid.NewGuid().ToString(),
                    Description = Guid.NewGuid().ToString(),
                    AgeRestriction = rand.Next(10),
                    CompanyId = rand.Next(10),
                    Price = Convert.ToDecimal(rand.NextDouble()),

                }
            };
    }
}
