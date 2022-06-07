using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using ToysAPI;
using System.Net;
using Newtonsoft.Json;
using Models;
using System.Net.Http.Headers;

namespace Test
{
    public class ToysControllerIntegrationTests
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Random rnd;

        public ToysControllerIntegrationTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _factory = new WebApplicationFactory<Program>();
            rnd = new();
        }
        [Fact]
       
        public async void TestGetToys()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();

            // Act
            var response = await client.GetAsync("/api/Toys/Get");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }

        [Fact]
       
        public async void TestPostToy()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();
            var toy = new ToysModel { Name = "New toy", Description = "This is a toy", Company = "Toy company", AgeRestriction = 5, Price = rnd.Next(50) };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(toy), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await client.PostAsync("/api/Toys/Add", httpContent);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }

        [Fact]
        
        public async void TestPutToy()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();
            var toy = new ToysModel() { Id = 2, Name = "Updated toy", Description = "This is a updated toy", Company = "Toy company", AgeRestriction = 5, Price = 10 };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(toy), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await client.PutAsync("/api/Toys/Update", httpContent);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }

        [Fact]
       
        public async void TestDeleteToy()
        {
            // Arrange
            int id = 4; //Change to a proper existin id, otherwise this will fail.
            var client = _factory.CreateDefaultClient();

            // Act
            var response = await client.DeleteAsync($"/api/Toys/{id}");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }
    }
}