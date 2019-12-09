﻿using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePlanController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ServicePlanController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>()) {
                return Json(ServicePlanRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>())
            {
                return Json(ServicePlanRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] ServicePlan ServicePlan)
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>())
            {
                if (ServicePlanRepository.Create(ServicePlan))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] ServicePlan ServicePlan)
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>())
            {
                if (ServicePlanRepository.Update(ServicePlan))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] ServicePlan ServicePlan)
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>())
            {
                if (ServicePlanRepository.Delete(ServicePlan))
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
                //_ServicePlanRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
