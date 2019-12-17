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
    class WorkerRoleControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private WorkerRoleController _workerRoleController;
        
        public WorkerRoleControllerTests()
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
        public void GetWorkerRole()
        {
            var mock = new Mock<IRepository<WorkerRole>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<WorkerRole>()).Returns(mock.Object);
            _workerRoleController = new WorkerRoleController(factoryMock.Object);

            var json = _workerRoleController.Get(1);
            var workerRole = json.Value as WorkerRole;
            Assert.NotNull(json);
            Assert.NotNull(workerRole);
            Assert.AreEqual(workerRole.Id, 1);
        }
        [Test]
        public void GetAllWorkerRolees()
        {
            var mock = new Mock<IRepository<WorkerRole>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<WorkerRole>()).Returns(mock.Object);
            _workerRoleController = new WorkerRoleController(factoryMock.Object);

            var json = _workerRoleController.GetAll();
            var workerRole = json.Value as List<WorkerRole>;
            Assert.NotNull(json);
            Assert.NotNull(workerRole);
            Assert.AreEqual(workerRole.Count, 2);

            //var mock1 = new Mock<IRepository<WorkerRole>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<WorkerRole>()).Returns(mock1.Object);
            //_workerRoleController = new WorkerRoleController(factoryMock1.Object);

            //json = _workerRoleController.GetAll();
            //workerRole = json.Value as List<WorkerRole>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<WorkerRole>();
            WorkerRole workerRoleStub = new WorkerRole { Id = 1 };
            var mock = new Mock<IRepository<WorkerRole>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<WorkerRole>())).Returns((WorkerRole workerRole) => {
                workerRole.Id = 1;
                memoryStore.Add(workerRole);
                return workerRole;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<WorkerRole>()).Returns(mock.Object);
            _workerRoleController = new WorkerRoleController(factoryMock.Object);
            var emptyJson = _workerRoleController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<WorkerRole>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _workerRoleController.Create(workerRoleStub);
            Assert.IsNotNull(json);
            var result = json.Value as WorkerRole;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Role, workerRoleStub.Role);
            var notEmptyJson = _workerRoleController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<WorkerRole>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            WorkerRole workerRole = new WorkerRole() { Id = 1 };
            var mock = new Mock<IRepository<WorkerRole>>();
            mock.Setup(repo => repo.Create(workerRole));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<WorkerRole>()).Returns(mock.Object);
            _workerRoleController = new WorkerRoleController(factoryMock.Object);
            //Assert.AreEqual(workerRole, factoryMock);
        }

        private WorkerRole GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<WorkerRole> GetAllTest()
        {
            var list = new List<WorkerRole>();
            WorkerRole a1 = new WorkerRole { Id = 1 };
            WorkerRole a2 = new WorkerRole { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public WorkerRole GetByIdTest(int i)
        {
            return new WorkerRole { Id = 1 };
        }
    }
}
