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
    class WorkerControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private WorkerController _workerController;
        
        public WorkerControllerTests()
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
        public void GetWorker()
        {
            var mock = new Mock<IRepository<Worker>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Worker>()).Returns(mock.Object);
            _workerController = new WorkerController(factoryMock.Object);

            var json = _workerController.Get(1);
            var worker = json.Value as Worker;
            Assert.NotNull(json);
            Assert.NotNull(worker);
            Assert.AreEqual(worker.Id, 1);
        }
        [Test]
        public void GetAllWorkeres()
        {
            var mock = new Mock<IRepository<Worker>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Worker>()).Returns(mock.Object);
            _workerController = new WorkerController(factoryMock.Object);

            var json = _workerController.GetAll();
            var worker = json.Value as List<Worker>;
            Assert.NotNull(json);
            Assert.NotNull(worker);
            Assert.AreEqual(worker.Count, 2);

            //var mock1 = new Mock<IRepository<Worker>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Worker>()).Returns(mock1.Object);
            //_workerController = new WorkerController(factoryMock1.Object);

            //json = _workerController.GetAll();
            //worker = json.Value as List<Worker>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<Worker>();
            Worker workerStub = new Worker { Id = 1 };
            var mock = new Mock<IRepository<Worker>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<Worker>())).Returns((Worker worker) => {
                worker.Id = 1;
                memoryStore.Add(worker);
                return worker;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Worker>()).Returns(mock.Object);
            _workerController = new WorkerController(factoryMock.Object);
            var emptyJson = _workerController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<Worker>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _workerController.Create(workerStub);
            Assert.IsNotNull(json);
            var result = json.Value as Worker;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Person, workerStub.Person);
            var notEmptyJson = _workerController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<Worker>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            Worker worker = new Worker() { Id = 1 };
            var mock = new Mock<IRepository<Worker>>();
            mock.Setup(repo => repo.Create(worker));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Worker>()).Returns(mock.Object);
            _workerController = new WorkerController(factoryMock.Object);
            //Assert.AreEqual(worker, factoryMock);
        }

        private Worker GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<Worker> GetAllTest()
        {
            var list = new List<Worker>();
            Worker a1 = new Worker { Id = 1 };
            Worker a2 = new Worker { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Worker GetByIdTest(int i)
        {
            return new Worker { Id = 1 };
        }
    }
}
