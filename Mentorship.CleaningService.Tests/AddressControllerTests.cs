using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Mentorship.CleaningService.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Mentorship.CleaningService.Tests
{
    [TestFixture]
    class AddressControllerTests
    {
        private AddressController _addressController;
        public AddressControllerTests(IServiceProvider provider)
        {
            _addressController = (AddressController) provider.GetService(typeof(AddressController)); // addressController;
        }
        private readonly IRepository<Address> _addressRepository;
        [Test]
        public void GetAddress()
        {
            //AddressController addressController = new AddressController();
            // Arrange
            var mock = new Mock<IRepository<Address>>();
            mock.Setup(repo => repo.GetById(1)).Returns(GetByIdTest(1));
            //var controller = new AddressController(mock.Object);

            //var result = controller.Get();
            //var jsonString =
            //@"{
            //    '$id': '1',
            //    'id': 1,
            //    'isDeleted': false,
            //    'streetName': null,
            //    'buildingNumber': null,
            //    'apartmentNumber': null,
            //    'city': 'Lviv',
            //    'clientAddresses': null
            //}";
            //Assert.Equals(GetByIdTest(1), controller.Get());
            //Assert.Equals(result, jsonString);
        }

        public Address GetByIdTest(int i)
        {
            return new Address { Id = 1, City = "Lviv" };
        }

    }
}
