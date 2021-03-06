﻿using System;
using System.Linq;
using Mentorship.CleaningService.BusinessLogic;
using Mentorship.CleaningService.DTO;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    //[Authorize]
    public class AddressController : Controller
    {
        private readonly IRepositoryFactory _factory;
        private readonly ICleaningServiceServiceFactory _serviceFactory;

        public AddressController(ICleaningServiceServiceFactory serviceFactory, IRepositoryFactory factory)
        {
            _factory = factory;
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        [Route("api/address/{id}")]
        public JsonResult Get(int id)
        {
            //using (var addressService = _serviceFactory.GetCleaningService<AddressDTO>())
            //{
            //    return Json(addressService.GetById(id));
            //}
            var addressService = _serviceFactory.GetCleaningService<AddressDTO>();
            return Json(addressService.GetById(id));
        }

        [HttpGet]
        [Route("api/addresses")]
        public JsonResult GetAll()
        {
            //using (var addressService = _serviceFactory.GetCleaningService<AddressDTO>())
            //{
            //    return Json(addressService.GetAll());
            //}
            var addressService = _serviceFactory.GetCleaningService<AddressDTO>() ;
            return Json(addressService.GetAll());
        }

        [HttpPost]
        [Route("api/address/create")]
        public JsonResult Create(Address address)
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                return Json(addressRepository.Create(address));
            }
        }

        [HttpPost]
        [Route("api/address/update")]
        public JsonResult Update(Address address)
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                return Json(addressRepository.Update(address));
            }
        }

        [HttpPost]
        [Route("api/address/delete")]
        public bool Delete(Address address)
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                return addressRepository.Delete(address);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_addressRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
