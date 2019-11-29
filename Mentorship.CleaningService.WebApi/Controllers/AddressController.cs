﻿using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IRepository<IEntity> _addressRepository;

        public AddressController(RepositoryFactory addressRepository) //, IServiceProvider provider
        {
            _addressRepository = addressRepository.GetRepository<Address>();//GetRepository<Address>();
            //_addressRepository = provider.GetService(typeof(IRepository<Address>)) as IRepository<Address>;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_addressRepository.GetById(1));
        }
        [HttpGet]
        //public JsonResult GetAll()
        //{
        //    return Json(_addressRepository.GetAll());
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _addressRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
