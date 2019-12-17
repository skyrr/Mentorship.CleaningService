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
    class ContractStatusControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private ContractStatusController _contractStatusController;
        
        public ContractStatusControllerTests()
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
        public void GetContractStatus()
        {
            var mock = new Mock<IRepository<ContractStatus>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ContractStatus>()).Returns(mock.Object);
            _contractStatusController = new ContractStatusController(factoryMock.Object);

            var json = _contractStatusController.Get(1);
            var contractStatus = json.Value as ContractStatus;
            Assert.NotNull(json);
            Assert.NotNull(contractStatus);
            Assert.AreEqual(contractStatus.Id, 1);
        }
        [Test]
        public void GetAllContractStatuses()
        {
            var mock = new Mock<IRepository<ContractStatus>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ContractStatus>()).Returns(mock.Object);
            _contractStatusController = new ContractStatusController(factoryMock.Object);

            var json = _contractStatusController.GetAll();
            var contractStatus = json.Value as List<ContractStatus>;
            Assert.NotNull(json);
            Assert.NotNull(contractStatus);
            Assert.AreEqual(contractStatus.Count, 2);

            //var mock1 = new Mock<IRepository<ContractStatus>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<ContractStatus>()).Returns(mock1.Object);
            //_contractStatusController = new ContractStatusController(factoryMock1.Object);

            //json = _contractStatusController.GetAll();
            //contractStatus = json.Value as List<ContractStatus>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<ContractStatus>();
            ContractStatus contractStatusStub = new ContractStatus { Id = 1 };
            var mock = new Mock<IRepository<ContractStatus>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<ContractStatus>())).Returns((ContractStatus contractStatus) => {
                contractStatus.Id = 1;
                memoryStore.Add(contractStatus);
                return contractStatus;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ContractStatus>()).Returns(mock.Object);
            _contractStatusController = new ContractStatusController(factoryMock.Object);
            var emptyJson = _contractStatusController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<ContractStatus>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _contractStatusController.Create(contractStatusStub);
            Assert.IsNotNull(json);
            var result = json.Value as ContractStatus;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.StatusName, (contractStatusStub.StatusName));
            var notEmptyJson = _contractStatusController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<ContractStatus>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            ContractStatus contractStatus = new ContractStatus() { Id = 1 };
            var mock = new Mock<IRepository<ContractStatus>>();
            mock.Setup(repo => repo.Create(contractStatus));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ContractStatus>()).Returns(mock.Object);
            _contractStatusController = new ContractStatusController(factoryMock.Object);
            //Assert.AreEqual(contractStatus, factoryMock);
        }

        private ContractStatus GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<ContractStatus> GetAllTest()
        {
            var list = new List<ContractStatus>();
            ContractStatus a1 = new ContractStatus { Id = 1 };
            ContractStatus a2 = new ContractStatus { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public ContractStatus GetByIdTest(int i)
        {
            return new ContractStatus { Id = 1 };
        }
    }
}
