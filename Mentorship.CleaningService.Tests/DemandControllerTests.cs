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
    class DemandControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private DemandController _demandController;
        
        public DemandControllerTests()
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
        public void GetDemand()
        {
            var mock = new Mock<IRepository<Demand>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Demand>()).Returns(mock.Object);
            _demandController = new DemandController(factoryMock.Object);

            var json = _demandController.Get(1);
            var demand = json.Value as Demand;
            Assert.NotNull(json);
            Assert.NotNull(demand);
            Assert.AreEqual(demand.Id, 1);
        }
        [Test]
        public void GetAllDemandes()
        {
            var mock = new Mock<IRepository<Demand>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Demand>()).Returns(mock.Object);
            _demandController = new DemandController(factoryMock.Object);

            var json = _demandController.GetAll();
            var demand = json.Value as List<Demand>;
            Assert.NotNull(json);
            Assert.NotNull(demand);
            Assert.AreEqual(demand.Count, 2);

            //var mock1 = new Mock<IRepository<Demand>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Demand>()).Returns(mock1.Object);
            //_demandController = new DemandController(factoryMock1.Object);

            //json = _demandController.GetAll();
            //demand = json.Value as List<Demand>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<Demand>();
            Demand demandStub = new Demand { Id = 1 };
            var mock = new Mock<IRepository<Demand>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<Demand>())).Returns((Demand demand) => {
                demand.Id = 1;
                memoryStore.Add(demand);
                return demand;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Demand>()).Returns(mock.Object);
            _demandController = new DemandController(factoryMock.Object);
            var emptyJson = _demandController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<Demand>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _demandController.Create(demandStub);
            Assert.IsNotNull(json);
            var result = json.Value as Demand;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Client, demandStub.Client);
            var notEmptyJson = _demandController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<Demand>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            Demand demand = new Demand() { Id = 1 };
            var mock = new Mock<IRepository<Demand>>();
            mock.Setup(repo => repo.Create(demand));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Demand>()).Returns(mock.Object);
            _demandController = new DemandController(factoryMock.Object);
            //Assert.AreEqual(demand, factoryMock);
        }

        private Demand GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<Demand> GetAllTest()
        {
            var list = new List<Demand>();
            Demand a1 = new Demand { Id = 1 };
            Demand a2 = new Demand { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Demand GetByIdTest(int i)
        {
            return new Demand { Id = 1 };
        }
    }
}
