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
        public JsonResult Create( Demand demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                return Json(DemandRepository.Create(demand));
            }
        }

        [HttpPost]
        [Route("api/Demand/update")]
        public JsonResult Update( Demand demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                return Json(DemandRepository.Update(demand));
            }
        }

        [HttpPost]
        [Route("api/Demand/delete")]
        public bool Delete( Demand demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                return DemandRepository.Delete(demand);
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
