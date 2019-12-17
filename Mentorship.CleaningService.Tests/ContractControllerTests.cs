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
    class ContractControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private ContractController _contractController;
        
        public ContractControllerTests()
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
        public void GetContract()
        {
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Contract>()).Returns(mock.Object);
            _contractController = new ContractController(factoryMock.Object);

            var json = _contractController.Get(1);
            var contract = json.Value as Contract;
            Assert.NotNull(json);
            Assert.NotNull(contract);
            Assert.AreEqual(contract.Id, 1);
        }
        [Test]
        public void GetAllContractes()
        {
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Contract>()).Returns(mock.Object);
            _contractController = new ContractController(factoryMock.Object);

            var json = _contractController.GetAll();
            var contract = json.Value as List<Contract>;
            Assert.NotNull(json);
            Assert.NotNull(contract);
            Assert.AreEqual(contract.Count, 2);

            //var mock1 = new Mock<IRepository<Contract>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Contract>()).Returns(mock1.Object);
            //_contractController = new ContractController(factoryMock1.Object);

            //json = _contractController.GetAll();
            //contract = json.Value as List<Contract>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<Contract>();
            Contract contractStub = new Contract { Id = 1 };
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<Contract>())).Returns((Contract contract) => {
                contract.Id = 1;
                memoryStore.Add(contract);
                return contract;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Contract>()).Returns(mock.Object);
            _contractController = new ContractController(factoryMock.Object);
            var emptyJson = _contractController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<Contract>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _contractController.Create(contractStub);
            Assert.IsNotNull(json);
            var result = json.Value as Contract;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Address, contractStub.Address);
            var notEmptyJson = _contractController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<Contract>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            Contract contract = new Contract() { Id = 1};
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(repo => repo.Create(contract));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Contract>()).Returns(mock.Object);
            _contractController = new ContractController(factoryMock.Object);
            //Assert.AreEqual(contract, factoryMock);
        }

        private Contract GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<Contract> GetAllTest()
        {
            var list = new List<Contract>();
            Contract a1 = new Contract { Id = 1 };
            Contract a2 = new Contract { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Contract GetByIdTest(int i)
        {
            return new Contract { Id = 1 };
        }
    }
}
