using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Mentorship.CleaningService.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Mentorship.CleaningService.Tests
{
    [TestFixture]
    class AddressControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private AddressController _addressController;
        
        public AddressControllerTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IRepositoryFactory, RepositoryFactory>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [SetUp]
        public void Init()
        {
            var mock = new Mock<IRepository<Address>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Address>()).Returns(mock.Object);
            _addressController = new AddressController(factoryMock.Object);
        }

        [Test]
        public void GetAddress()
        {
            var json =_addressController.Get();
            var address = json.Value as Address;
            Assert.NotNull(json);
            Assert.NotNull(address);
            Assert.AreEqual(address.Id, 1);
            Assert.AreEqual(address.City, "Lviv");
            }

        public Address GetByIdTest(int i)
        {
            return new Address { Id = 1, City = "Lviv" };
        }

    }
}
