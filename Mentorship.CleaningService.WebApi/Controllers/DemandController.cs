using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class DemandController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public DemandController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Demand/{id}")]

        public JsonResult Get(int id)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>()) {
                return Json(DemandRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/Demands")]
        public JsonResult GetAll()
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                return Json(DemandRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/Demand/create")]
        public JsonResult Create([FromForm] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                return Json(DemandRepository.Create(Demand));
            }
        }

        [HttpPost]
        [Route("api/Demand/update")]
        public JsonResult Update([FromForm] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                return Json(DemandRepository.Update(Demand));
            }
        }

        [HttpPost]
        [Route("api/Demand/delete")]
        public bool Delete([FromForm] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                if (DemandRepository.Delete(Demand))
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
                //_DemandRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
