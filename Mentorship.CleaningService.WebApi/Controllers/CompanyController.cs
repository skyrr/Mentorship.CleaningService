﻿using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public CompanyController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            using (var CompanyRepository = _factory.GetRepository<Company>()) {
                return Json(CompanyRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var CompanyRepository = _factory.GetRepository<Company>())
            {
                return Json(CompanyRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Company Company)
        {
            using (var CompanyRepository = _factory.GetRepository<Company>())
            {
                if (CompanyRepository.Create(Company))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] Company Company)
        {
            using (var CompanyRepository = _factory.GetRepository<Company>())
            {
                if (CompanyRepository.Update(Company))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] Company Company)
        {
            using (var CompanyRepository = _factory.GetRepository<Company>())
            {
                if (CompanyRepository.Delete(Company))
                {
                    return true;
                }
                else return false;
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_CompanyRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
