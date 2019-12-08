using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public DemandController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get([FromBody] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>()) {
                return Json(DemandRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                return Json(DemandRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                if (DemandRepository.Create(Demand))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] Demand Demand)
        {
            using (var DemandRepository = _factory.GetRepository<Demand>())
            {
                if (DemandRepository.Update(Demand))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] Demand Demand)
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
