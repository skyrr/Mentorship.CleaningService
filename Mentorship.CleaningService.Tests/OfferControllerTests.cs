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
    class OfferControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private OfferController _offerController;
        
        public OfferControllerTests()
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
        public void GetOffer()
        {
            var mock = new Mock<IRepository<Offer>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Offer>()).Returns(mock.Object);
            _offerController = new OfferController(factoryMock.Object);

            var json = _offerController.Get(1);
            var offer = json.Value as Offer;
            Assert.NotNull(json);
            Assert.NotNull(offer);
            Assert.AreEqual(offer.Id, 1);
        }
        [Test]
        public void GetAllOfferes()
        {
            var mock = new Mock<IRepository<Offer>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Offer>()).Returns(mock.Object);
            _offerController = new OfferController(factoryMock.Object);

            var json = _offerController.GetAll();
            var offer = json.Value as List<Offer>;
            Assert.NotNull(json);
            Assert.NotNull(offer);
            Assert.AreEqual(offer.Count, 2);

            //var mock1 = new Mock<IRepository<Offer>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Offer>()).Returns(mock1.Object);
            //_offerController = new OfferController(factoryMock1.Object);

            //json = _offerController.GetAll();
            //offer = json.Value as List<Offer>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<Offer>();
            Offer offerStub = new Offer { Id = 1 };
            var mock = new Mock<IRepository<Offer>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<Offer>())).Returns((Offer offer) => {
                offer.Id = 1;
                memoryStore.Add(offer);
                return offer;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Offer>()).Returns(mock.Object);
            _offerController = new OfferController(factoryMock.Object);
            var emptyJson = _offerController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<Offer>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _offerController.Create(offerStub);
            Assert.IsNotNull(json);
            var result = json.Value as Offer;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Company, offerStub.Company);
            var notEmptyJson = _offerController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<Offer>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            Offer offer = new Offer() { Id = 1 };
            var mock = new Mock<IRepository<Offer>>();
            mock.Setup(repo => repo.Create(offer));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Offer>()).Returns(mock.Object);
            _offerController = new OfferController(factoryMock.Object);
            //Assert.AreEqual(offer, factoryMock);
        }

        private Offer GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<Offer> GetAllTest()
        {
            var list = new List<Offer>();
            Offer a1 = new Offer { Id = 1 };
            Offer a2 = new Offer { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Offer GetByIdTest(int i)
        {
            return new Offer { Id = 1 };
        }
    }
}
