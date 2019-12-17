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
    class OfferStatusControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private OfferStatusController _offerStatusController;
        
        public OfferStatusControllerTests()
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
        public void GetOfferStatus()
        {
            var mock = new Mock<IRepository<OfferStatus>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<OfferStatus>()).Returns(mock.Object);
            _offerStatusController = new OfferStatusController(factoryMock.Object);

            var json = _offerStatusController.Get(1);
            var offerStatus = json.Value as OfferStatus;
            Assert.NotNull(json);
            Assert.NotNull(offerStatus);
            Assert.AreEqual(offerStatus.Id, 1);
        }
        [Test]
        public void GetAllOfferStatuses()
        {
            var mock = new Mock<IRepository<OfferStatus>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<OfferStatus>()).Returns(mock.Object);
            _offerStatusController = new OfferStatusController(factoryMock.Object);

            var json = _offerStatusController.GetAll();
            var offerStatus = json.Value as List<OfferStatus>;
            Assert.NotNull(json);
            Assert.NotNull(offerStatus);
            Assert.AreEqual(offerStatus.Count, 2);

            //var mock1 = new Mock<IRepository<OfferStatus>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<OfferStatus>()).Returns(mock1.Object);
            //_offerStatusController = new OfferStatusController(factoryMock1.Object);

            //json = _offerStatusController.GetAll();
            //offerStatus = json.Value as List<OfferStatus>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<OfferStatus>();
            OfferStatus offerStatusStub = new OfferStatus { Id = 1 };
            var mock = new Mock<IRepository<OfferStatus>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<OfferStatus>())).Returns((OfferStatus offerStatus) => {
                offerStatus.Id = 1;
                memoryStore.Add(offerStatus);
                return offerStatus;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<OfferStatus>()).Returns(mock.Object);
            _offerStatusController = new OfferStatusController(factoryMock.Object);
            var emptyJson = _offerStatusController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<OfferStatus>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _offerStatusController.Create(offerStatusStub);
            Assert.IsNotNull(json);
            var result = json.Value as OfferStatus;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.StatusName, offerStatusStub.StatusName);
            var notEmptyJson = _offerStatusController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<OfferStatus>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            OfferStatus offerStatus = new OfferStatus() { Id = 1 };
            var mock = new Mock<IRepository<OfferStatus>>();
            mock.Setup(repo => repo.Create(offerStatus));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<OfferStatus>()).Returns(mock.Object);
            _offerStatusController = new OfferStatusController(factoryMock.Object);
            //Assert.AreEqual(offerStatus, factoryMock);
        }

        private OfferStatus GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<OfferStatus> GetAllTest()
        {
            var list = new List<OfferStatus>();
            OfferStatus a1 = new OfferStatus { Id = 1 };
            OfferStatus a2 = new OfferStatus { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public OfferStatus GetByIdTest(int i)
        {
            return new OfferStatus { Id = 1 };
        }
    }
}
