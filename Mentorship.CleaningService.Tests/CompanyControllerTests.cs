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
    class CompanyControllerTests
    {
        private readonly IServiceProvider _serviceProvider;
        private CompanyController _companyController;
        
        public CompanyControllerTests()
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
        public void GetCompany()
        {
            var mock = new Mock<IRepository<Company>>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(GetByIdTest(1));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Company>()).Returns(mock.Object);
            _companyController = new CompanyController(factoryMock.Object);

            var json = _companyController.Get(1);
            var company = json.Value as Company;
            Assert.NotNull(json);
            Assert.NotNull(company);
            Assert.AreEqual(company.Id, 1);
        }
        [Test]
        public void GetAllCompanyes()
        {
            var mock = new Mock<IRepository<Company>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetAllTest());
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Company>()).Returns(mock.Object);
            _companyController = new CompanyController(factoryMock.Object);

            var json = _companyController.GetAll();
            var company = json.Value as List<Company>;
            Assert.NotNull(json);
            Assert.NotNull(company);
            Assert.AreEqual(company.Count, 2);

            //var mock1 = new Mock<IRepository<Company>>();
            //mock1.Setup(repo => repo.GetAll().FirstOrDefault()).Returns(GetFirstOrDefaultTest(1));
            //var factoryMock1 = new Mock<IRepositoryFactory>();
            //factoryMock1.Setup(f => f.GetRepository<Company>()).Returns(mock1.Object);
            //_companyController = new CompanyController(factoryMock1.Object);

            //json = _companyController.GetAll();
            //company = json.Value as List<Company>;
            //Assert.AreEqual();

        }

        [Test]
        public void Create()
        {
            var memoryStore = new List<Company>();
            Company companyStub = new Company { CompanyName = "Lviv" };
            var mock = new Mock<IRepository<Company>>();
            mock.Setup(repo => repo.GetAll()).Returns(memoryStore.AsQueryable());
            mock.Setup(repo => repo.Create(It.IsAny<Company>())).Returns((Company company) => {
                company.Id = 1;
                memoryStore.Add(company);
                return company;
            });
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Company>()).Returns(mock.Object);
            _companyController = new CompanyController(factoryMock.Object);
            var emptyJson = _companyController.GetAll();
            Assert.IsNotNull(emptyJson);
            var emptyStore = emptyJson.Value as List<Company>;
            Assert.IsNotNull(emptyStore);
            Assert.AreEqual(emptyStore.Count, 0);
            var json = _companyController.Create(companyStub);
            Assert.IsNotNull(json);
            var result = json.Value as Company;
            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.CompanyName, companyStub.CompanyName);
            var notEmptyJson = _companyController.GetAll();
            Assert.IsNotNull(notEmptyJson);
            var notEmptyStore = notEmptyJson.Value as List<Company>;
            Assert.IsNotNull(notEmptyStore);
            Assert.AreEqual(notEmptyStore.Count, 1);
        }

        [Test]
        public void Create2()
        {
            Company company = new Company() { Id = 1};
            var mock = new Mock<IRepository<Company>>();
            mock.Setup(repo => repo.Create(company));
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock.Setup(f => f.GetRepository<Company>()).Returns(mock.Object);
            _companyController = new CompanyController(factoryMock.Object);
            //Assert.AreEqual(company, factoryMock);
        }

        private Company GetFirstOrDefaultTest(int i)
        {
            return GetByIdTest(i);
        }

        private IQueryable<Company> GetAllTest()
        {
            var list = new List<Company>();
            Company a1 = new Company { Id = 1 };
            Company a2 = new Company { Id = 2 };
            list.Add(a1);
            list.Add(a2);
            return list.AsQueryable();
        }

        public Company GetByIdTest(int i)
        {
            return new Company { Id = 1 };
        }
    }
}
