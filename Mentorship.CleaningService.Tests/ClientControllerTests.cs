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
    class ClientControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private ClientController _clientController;
        
        public ClientControllerTests()
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
        public void GetClient()
        {
            var mock = new Mock<IRepository<Client>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Client>()).Returns(mock.Object);
            _clientController = new ClientController(factoryMock.Object);

            var json = _clientController.Get(1);
            var client = json.Value as Client;
            Assert.NotNull(json);
            Assert.NotNull(client);
            Assert.AreEqual(client.Id, 1);
        }
        [Test]
        public void GetAllClients()
        {
            var mock = new Mock<IRepository<Client>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Client>()).Returns(mock.Object);
            _clientController = new ClientController(factoryMock.Object);

            var json = _clientController.GetAll();
            var client = json.Value as List<Client>;
            Assert.NotNull(json);
            Assert.NotNull(client);
            Assert.AreEqual(client.Count, 2);

            //var mock1 = new Mock<IRepository<Client>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Client>()).Returns(mock1.Object);
            //_clientController = new ClientController(factoryMock1.Object);

            //json = _clientController.GetAll();
            //client = json.Value as List<Client>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<Client>();
            Client clientStub = new Client { Id = 1 };
            var mock = new Mock<IRepository<Client>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<Client>())).Returns((Client client) => {
                client.Id = 1;
                memoryStore.Add(client);
                return client;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Client>()).Returns(mock.Object);
            _clientController = new ClientController(factoryMock.Object);
            var emptyJson = _clientController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<Client>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _clientController.Create(clientStub);
            Assert.IsNotNull(json);
            var result = json.Value as Client;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Person, clientStub.Person);
            var notEmptyJson = _clientController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<Client>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            Client client = new Client() { Id = 1};
            var mock = new Mock<IRepository<Client>>();
            mock.Setup(repo => repo.Create(client));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Client>()).Returns(mock.Object);
            _clientController = new ClientController(factoryMock.Object);
            //Assert.AreEqual(client, factoryMock);
        }

        private Client GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<Client> GetAllTest()
        {
            var list = new List<Client>();
            Client a1 = new Client { Id = 1};
            Client a2 = new Client { Id = 2};
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Client GetByIdTest(int i)
        {
            return new Client { Id = 1};
        }
    }
}
