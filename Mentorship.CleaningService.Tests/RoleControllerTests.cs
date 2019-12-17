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
    class RoleControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private RoleController _roleController;
        
        public RoleControllerTests()
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
        public void GetRole()
        {
            var mock = new Mock<IRepository<Role>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Role>()).Returns(mock.Object);
            _roleController = new RoleController(factoryMock.Object);

            var json = _roleController.Get(1);
            var role = json.Value as Role;
            Assert.NotNull(json);
            Assert.NotNull(role);
            Assert.AreEqual(role.Id, 1);
        }
        [Test]
        public void GetAllRolees()
        {
            var mock = new Mock<IRepository<Role>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Role>()).Returns(mock.Object);
            _roleController = new RoleController(factoryMock.Object);

            var json = _roleController.GetAll();
            var role = json.Value as List<Role>;
            Assert.NotNull(json);
            Assert.NotNull(role);
            Assert.AreEqual(role.Count, 2);

            //var mock1 = new Mock<IRepository<Role>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Role>()).Returns(mock1.Object);
            //_roleController = new RoleController(factoryMock1.Object);

            //json = _roleController.GetAll();
            //role = json.Value as List<Role>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<Role>();
            Role roleStub = new Role { Id = 1 };
            var mock = new Mock<IRepository<Role>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<Role>())).Returns((Role role) => {
                role.Id = 1;
                memoryStore.Add(role);
                return role;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Role>()).Returns(mock.Object);
            _roleController = new RoleController(factoryMock.Object);
            var emptyJson = _roleController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<Role>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _roleController.Create(roleStub);
            Assert.IsNotNull(json);
            var result = json.Value as Role;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Roles, roleStub.Roles);
            var notEmptyJson = _roleController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<Role>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            Role role = new Role() { Id = 1 };
            var mock = new Mock<IRepository<Role>>();
            mock.Setup(repo => repo.Create(role));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Role>()).Returns(mock.Object);
            _roleController = new RoleController(factoryMock.Object);
            //Assert.AreEqual(role, factoryMock);
        }

        private Role GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<Role> GetAllTest()
        {
            var list = new List<Role>();
            Role a1 = new Role { Id = 1 };
            Role a2 = new Role { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Role GetByIdTest(int i)
        {
            return new Role { Id = 1 };
        }
    }
}
