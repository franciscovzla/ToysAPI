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

namespace Test
{
    public class ToysControllerTests
    {
        Mock <IToyService> _toysServiceStub = new Mock<IToyService>();
        private readonly Random rand = new();
        [Fact]
        public async Task GetToysWithNoItems()
        {
            _toysServiceStub.Setup(service => service.GetToys()).ReturnsAsync(null as ToysModel[]);

          
            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.GetToys();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<ToysModel>>>(result);
        }

        [Fact]
        public async Task GetToysReturnsAllItems()
        {
            // Arrange
            var expectedItems = new[] { GenerateRandomObjectForList(), GenerateRandomObjectForList(), GenerateRandomObjectForList() };

            _toysServiceStub.Setup(service => service.GetToys())
                .ReturnsAsync(expectedItems);
            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.GetToys();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<ToysModel>>>(result);
        }

        [Fact]
        public async Task AddToy()
        {
            // Arrange
            var invalidModel = GenerateBadRandomObjectWithNoName();

            _toysServiceStub.SetupAdd(service => service.AddToy(invalidModel));
              

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.AddToy(invalidModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateToy_WithValidModelAndId_ReturnsOk()
        {
            // Arrange
            var validModel = GenerateRandomObjectForUpdate();

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
            var invalidModel = GenerateBadRandomObjectWithNoId();

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
            var validModel = GenerateRandomObjectForUpdate();

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
            var invalidModel = GenerateBadRandomObjectWithNoId();

            _toysServiceStub.Setup(service => service.DeleteToy(invalidModel.Id))
                .ReturnsAsync(false);

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.DeleteToy(invalidModel.Id);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }
        private ToysModel GenerateRandomObjectForList()
        {
            return new()
            {
                Id = rand.Next(100),
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                AgeRestriction = rand.Next(10),
                Company = It.IsAny<string>(),
                Price = Convert.ToDecimal(rand.NextDouble())
            };
        }


        private ToysModel GenerateBadRandomObjectWithNoName()
        {
            return new()
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                AgeRestriction = rand.Next(10),
                Company = Guid.NewGuid().ToString(),
                Price = Convert.ToDecimal(rand.NextDouble())
            };
        }

        private ToysModel GenerateRandomObjectForUpdate()
        {
            return new()
            {
                Id = rand.Next(100),
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                AgeRestriction = rand.Next(10),
               Company = It.IsAny<string>(),
                Price = Convert.ToDecimal(rand.NextDouble()),
               
            };
        }

        private ToysModel GenerateBadRandomObjectWithNoId()
        {
            return new()
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                AgeRestriction = rand.Next(10),
                Company = It.IsAny<string>(),
                Price = Convert.ToDecimal(rand.NextDouble())
            };
        }
    }
}
