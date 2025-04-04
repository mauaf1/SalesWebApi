using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SalesWebAPI.Controllers;
using SalesWebAPI.Interfaces;
using SalesWebAPI.Models;
using System.Collections.Generic;

namespace SalesAPITestProject
{
    [TestClass]
    public class CustomersControllerTest
    {
        private Mock<ICustomerRepository> _mockRepo;
        private CustomersController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<ICustomerRepository>();
            _controller = new CustomersController(_mockRepo.Object);
        }

        [TestMethod]
        public void GetCustomers_ShouldReturnLists()
        {
            // Arrange
            var mockCustomers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "John Doe" },
                new Customer { CustomerId = 2, Name = "Jane Doe" }
            };
            _mockRepo.Setup(repo => repo.GetCustomers()).Returns(mockCustomers);

            // Act
            var result = _controller.Get() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(List<Customer>));
            Assert.AreEqual(2, ((List<Customer>)result.Value).Count);
        }

        [TestMethod]
        public void GetCustomers_When_Called_returnsNull()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetCustomers()).Returns((List<Customer>)null);

            // Act
            var result = _controller.Get() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNull(result.Value);
        }

        [TestMethod]
        public void GetCustomer_WithAnInvalidId_ShouldReturnNull()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Customer)null);

            // Act
            var result = _controller.Get(99); // Invalid ID

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCustomer_WithAValidId_ShouldReturnCustomer()
        {
            // Arrange
            var mockCustomer = new Customer { CustomerId = 1, Name = "John Doe" };
            _mockRepo.Setup(repo => repo.GetById(1)).Returns(mockCustomer);

            // Act
            var result = _controller.Get(1) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(Customer));
            Assert.AreEqual(mockCustomer, result.Value);
        }
    }
}
