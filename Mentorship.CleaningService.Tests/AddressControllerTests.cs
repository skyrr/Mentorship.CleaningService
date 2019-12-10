using System;
using System.Collections.Generic;
using System.Linq;
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

        //[SetUp]
        //public void Init()
        //{
        //}

        [Test]
        public void GetAddress()
        {
            var mock = new Mock<IRepository<Address>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Address>()).Returns(mock.Object);
            _addressController = new AddressController(factoryMock.Object);

            var json = _addressController.Get(1);
            var address = json.Value as Address;
            Assert.NotNull(json);
            Assert.NotNull(address);
            Assert.AreEqual(address.Id, 1);
            Assert.AreEqual(address.City, "Lviv");
        }
        [Test]
        public void GetAllAddresses()
        {
            var mock = new Mock<IRepository<Address>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Address>()).Returns(mock.Object);
            _addressController = new AddressController(factoryMock.Object);

            var json = _addressController.GetAll();
            var address = json.Value as List<Address>;
            foreach (var item in address)
            {
                Assert.NotNull(json);
                Assert.NotNull(address);
                Assert.AreEqual(item.Id, 1);
                Assert.AreEqual(item.City, "Lviv");
            }

        }

        private IQueryable<Address> GetAllTest()
        {
            var list = new List<Address>();
            Address a1 = new Address { Id = 1, City = "Lviv" };
            Address a2 = new Address { Id = 2, City = "Lviv" };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Address GetByIdTest(int i)
        {
            return new Address { Id = 1, City = "Lviv" };
        }

    }
}
