using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class ServicePlanController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ServicePlanController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/ServicePlan/{id}")]
        public JsonResult Get(int id)
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>()) {
                return Json(ServicePlanRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/ServicePlans")]
        public JsonResult GetAll()
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>())
            {
                return Json(ServicePlanRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/ServicePlan/create")]
        public JsonResult Create([FromForm] ServicePlan servicePlan)
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>())
            {
                return Json(ServicePlanRepository.Create(servicePlan));
            }
        }

        [HttpPost]
        [Route("api/ServicePlan/update")]
        public JsonResult Update([FromForm] ServicePlan servicePlan)
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>())
            {
                return Json(ServicePlanRepository.Update(servicePlan));
            }
        }

        [HttpPost]
        [Route("api/ServicePlan/delete")]
        public bool Delete([FromForm] ServicePlan servicePlan)
        {
            using (var ServicePlanRepository = _factory.GetRepository<ServicePlan>())
            {
                return ServicePlanRepository.Delete(servicePlan);
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
