using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesWebAPI.Controllers;
using SalesWebAPI.Interfaces;
using SalesWebAPI.Models;
using System.Numerics;

namespace SalesAPITestProject
{
    [TestClass]
    public class CustomersControllerTest
    {
        [TestMethod]
        public void GetCustomers_ShouldReturnLists()
        {
            //
        }
        [TestMethod]
        public void GetCustomers_When_Called_returnsNull()
        {
            //

        }

        [TestMethod]
        public void GetCustomer_WithAnInvalidId_ShouldReturnNull()
        {
            //
        }



        [TestMethod]
        public void GetCustomer_WithAValidId_ShouldReturnCustomer()
        {
           //
        }

    }
}