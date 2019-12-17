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
    class PersonControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private PersonController _personController;
        
        public PersonControllerTests()
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
        public void GetPerson()
        {
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Person>()).Returns(mock.Object);
            _personController = new PersonController(factoryMock.Object);

            var json = _personController.Get(1);
            var person = json.Value as Person;
            Assert.NotNull(json);
            Assert.NotNull(person);
            Assert.AreEqual(person.Id, 1);
        }
        [Test]
        public void GetAllPersones()
        {
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Person>()).Returns(mock.Object);
            _personController = new PersonController(factoryMock.Object);

            var json = _personController.GetAll();
            var person = json.Value as List<Person>;
            Assert.NotNull(json);
            Assert.NotNull(person);
            Assert.AreEqual(person.Count, 2);

            //var mock1 = new Mock<IRepository<Person>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Person>()).Returns(mock1.Object);
            //_personController = new PersonController(factoryMock1.Object);

            //json = _personController.GetAll();
            //person = json.Value as List<Person>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<Person>();
            Person personStub = new Person { Id = 1 };
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<Person>())).Returns((Person person) => {
                person.Id = 1;
                memoryStore.Add(person);
                return person;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Person>()).Returns(mock.Object);
            _personController = new PersonController(factoryMock.Object);
            var emptyJson = _personController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<Person>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _personController.Create(personStub);
            Assert.IsNotNull(json);
            var result = json.Value as Person;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Address, personStub.Address);
            var notEmptyJson = _personController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<Person>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            Person person = new Person() { Id = 1 };
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(repo => repo.Create(person));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Person>()).Returns(mock.Object);
            _personController = new PersonController(factoryMock.Object);
            //Assert.AreEqual(person, factoryMock);
        }

        private Person GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<Person> GetAllTest()
        {
            var list = new List<Person>();
            Person a1 = new Person { Id = 1 };
            Person a2 = new Person { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Person GetByIdTest(int i)
        {
            return new Person { Id = 1 };
        }
    }
}
