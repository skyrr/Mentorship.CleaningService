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
    class DemandStatusControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private DemandStatusController _demandStatusController;
        
        public DemandStatusControllerTests()
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
        public void GetDemandStatus()
        {
            var mock = new Mock<IRepository<DemandStatus>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<DemandStatus>()).Returns(mock.Object);
            _demandStatusController = new DemandStatusController(factoryMock.Object);

            var json = _demandStatusController.Get(1);
            var demandStatus = json.Value as DemandStatus;
            Assert.NotNull(json);
            Assert.NotNull(demandStatus);
            Assert.AreEqual(demandStatus.Id, 1);
        }
        [Test]
        public void GetAllDemandStatuses()
        {
            var mock = new Mock<IRepository<DemandStatus>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<DemandStatus>()).Returns(mock.Object);
            _demandStatusController = new DemandStatusController(factoryMock.Object);

            var json = _demandStatusController.GetAll();
            var demandStatus = json.Value as List<DemandStatus>;
            Assert.NotNull(json);
            Assert.NotNull(demandStatus);
            Assert.AreEqual(demandStatus.Count, 2);

            //var mock1 = new Mock<IRepository<DemandStatus>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<DemandStatus>()).Returns(mock1.Object);
            //_demandStatusController = new DemandStatusController(factoryMock1.Object);

            //json = _demandStatusController.GetAll();
            //demandStatus = json.Value as List<DemandStatus>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<DemandStatus>();
            DemandStatus demandStatusStub = new DemandStatus { Id = 1 };
            var mock = new Mock<IRepository<DemandStatus>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<DemandStatus>())).Returns((DemandStatus demandStatus) => {
                demandStatus.Id = 1;
                memoryStore.Add(demandStatus);
                return demandStatus;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<DemandStatus>()).Returns(mock.Object);
            _demandStatusController = new DemandStatusController(factoryMock.Object);
            var emptyJson = _demandStatusController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<DemandStatus>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _demandStatusController.Create(demandStatusStub);
            Assert.IsNotNull(json);
            var result = json.Value as DemandStatus;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.StatusName, demandStatusStub.StatusName);
            var notEmptyJson = _demandStatusController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<DemandStatus>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            DemandStatus demandStatus = new DemandStatus() { Id = 1 };
            var mock = new Mock<IRepository<DemandStatus>>();
            mock.Setup(repo => repo.Create(demandStatus));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<DemandStatus>()).Returns(mock.Object);
            _demandStatusController = new DemandStatusController(factoryMock.Object);
            //Assert.AreEqual(demandStatus, factoryMock);
        }

        private DemandStatus GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<DemandStatus> GetAllTest()
        {
            var list = new List<DemandStatus>();
            DemandStatus a1 = new DemandStatus { Id = 1 };
            DemandStatus a2 = new DemandStatus { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public DemandStatus GetByIdTest(int i)
        {
            return new DemandStatus { Id = 1 };
        }
    }
}
