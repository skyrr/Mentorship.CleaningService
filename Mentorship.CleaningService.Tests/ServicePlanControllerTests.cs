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

namespace Mentorship.CleaningServicePlan.Tests
{
    [TestFixture]
    class ServicePlanControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private ServicePlanController _servicePlanController;
        
        public ServicePlanControllerTests()
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
        public void GetServicePlan()
        {
            var mock = new Mock<IRepository<ServicePlan>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ServicePlan>()).Returns(mock.Object);
            _servicePlanController = new ServicePlanController(factoryMock.Object);

            var json = _servicePlanController.Get(1);
            var servicePlan = json.Value as ServicePlan;
            Assert.NotNull(json);
            Assert.NotNull(servicePlan);
            Assert.AreEqual(servicePlan.Id, 1);
        }
        [Test]
        public void GetAllServicePlanes()
        {
            var mock = new Mock<IRepository<ServicePlan>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ServicePlan>()).Returns(mock.Object);
            _servicePlanController = new ServicePlanController(factoryMock.Object);

            var json = _servicePlanController.GetAll();
            var servicePlan = json.Value as List<ServicePlan>;
            Assert.NotNull(json);
            Assert.NotNull(servicePlan);
            Assert.AreEqual(servicePlan.Count, 2);

            //var mock1 = new Mock<IRepository<ServicePlan>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<ServicePlan>()).Returns(mock1.Object);
            //_servicePlanController = new ServicePlanController(factoryMock1.Object);

            //json = _servicePlanController.GetAll();
            //servicePlan = json.Value as List<ServicePlan>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<ServicePlan>();
            ServicePlan servicePlanStub = new ServicePlan { Id = 1 };
            var mock = new Mock<IRepository<ServicePlan>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<ServicePlan>())).Returns((ServicePlan servicePlan) => {
                servicePlan.Id = 1;
                memoryStore.Add(servicePlan);
                return servicePlan;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ServicePlan>()).Returns(mock.Object);
            _servicePlanController = new ServicePlanController(factoryMock.Object);
            var emptyJson = _servicePlanController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<ServicePlan>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _servicePlanController.Create(servicePlanStub);
            Assert.IsNotNull(json);
            var result = json.Value as ServicePlan;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.ServicePlanName, servicePlanStub.ServicePlanName);
            var notEmptyJson = _servicePlanController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<ServicePlan>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            ServicePlan servicePlan = new ServicePlan() { Id = 1 };
            var mock = new Mock<IRepository<ServicePlan>>();
            mock.Setup(repo => repo.Create(servicePlan));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<ServicePlan>()).Returns(mock.Object);
            _servicePlanController = new ServicePlanController(factoryMock.Object);
            //Assert.AreEqual(servicePlan, factoryMock);
        }

        private ServicePlan GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<ServicePlan> GetAllTest()
        {
            var list = new List<ServicePlan>();
            ServicePlan a1 = new ServicePlan { Id = 1 };
            ServicePlan a2 = new ServicePlan { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public ServicePlan GetByIdTest(int i)
        {
            return new ServicePlan { Id = 1 };
        }
    }
}
