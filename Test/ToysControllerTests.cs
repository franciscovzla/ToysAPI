﻿using System;

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
        private Mock <IToyService> _toysServiceStub = new Mock<IToyService>();
        private Random rand = new();
       

        [Fact]
        public async Task GetToys()
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
        public async Task UpdateToy_WithValidModelAndId_ReturnsOk()
        {
            // Arrange
            var validModel = GenerateRandomObjectForUpdate(true);

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
            var validModel = GenerateRandomObjectForUpdate(true);

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
            //TODO: It might be worthy to move these random methods to a Fixture
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



        //TODO: Whats the difference between this one and the GenerateRandomObjectForList?
        private ToysModel GenerateRandomObjectForUpdate(bool returnId)
        {
            return new()
            {
                Id = returnId == true ? rand.Next(100) : null,
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                AgeRestriction = rand.Next(10),
                Company = It.IsAny<string>(),
                Price = Convert.ToDecimal(rand.NextDouble()),
               
            };
        }


        //TODO: Same here, if there is a very small difference try using overload or a parameter that set if it should include or not the ID

        //KISS, DRY, YAIGN
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
