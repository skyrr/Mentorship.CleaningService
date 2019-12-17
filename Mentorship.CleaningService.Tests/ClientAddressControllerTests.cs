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
    class ClientAddressControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private ClientAddressController _clientAddressController;
        
        public ClientAddressControllerTests()
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
        public void GetById()
        {
            var mock = new Mock<IRepository<ClientAddress>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ClientAddress>()).Returns(mock.Object);
            _clientAddressController = new ClientAddressController(factoryMock.Object);

            var json = _clientAddressController.Get(1);
            var clientAddress = json.Value as ClientAddress;
            Assert.NotNull(json);
            Assert.NotNull(clientAddress);
            Assert.AreEqual(clientAddress.Id, 1);
        }
        [Test]
        public void GetAllAddresses()
        {
            var mock = new Mock<IRepository<ClientAddress>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ClientAddress>()).Returns(mock.Object);
            _clientAddressController = new ClientAddressController(factoryMock.Object);

            var json = _clientAddressController.GetAll();
            var address = json.Value as List<ClientAddress>;
            Assert.NotNull(json);
            Assert.NotNull(address);
            Assert.AreEqual(address.Count, 2);

            //var mock1 = new Mock<IRepository<Address>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Address>()).Returns(mock1.Object);
            //_clientAddressController = new AddressController(factoryMock1.Object);

            //json = _clientAddressController.GetAll();
            //address = json.Value as List<Address>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<ClientAddress>();
            ClientAddress clientAddressStub = new ClientAddress { Id =  1};
            var mock = new Mock<IRepository<ClientAddress>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<ClientAddress>())).Returns((Address address) => {
                address.Id = 1;
                memoryStore.Add(clientAddressStub);
                return clientAddressStub;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ClientAddress>()).Returns(mock.Object);
            _clientAddressController = new ClientAddressController(factoryMock.Object);
            var emptyJson = _clientAddressController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<ClientAddress>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _clientAddressController.Create(clientAddressStub);
            Assert.IsNotNull(json);
            var result = json.Value as Address;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.City, clientAddressStub.Id);
            var notEmptyJson = _clientAddressController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<ClientAddress>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            ClientAddress clientAddress = new ClientAddress() { Id = 1};
            var mock = new Mock<IRepository<ClientAddress>>();
            mock.Setup(repo => repo.Create(clientAddress));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ClientAddress>()).Returns(mock.Object);
            _clientAddressController = new ClientAddressController(factoryMock.Object);
            //Assert.AreEqual(address, factoryMock);
        }

        private ClientAddress GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<ClientAddress> GetAllTest()
        {
            var list = new List<ClientAddress>();
            ClientAddress a1 = new ClientAddress { Id = 1};
            ClientAddress a2 = new ClientAddress { Id = 2};
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public ClientAddress GetByIdTest(int i)
        {
            return new ClientAddress { Id = 1};
        }
    }
}
