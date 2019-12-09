using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandStatusController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public DemandStatusController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>()) {
                return Json(DemandStatusRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>())
            {
                return Json(DemandStatusRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] DemandStatus DemandStatus)
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>())
            {
                if (DemandStatusRepository.Create(DemandStatus))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] DemandStatus DemandStatus)
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>())
            {
                if (DemandStatusRepository.Update(DemandStatus))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] DemandStatus DemandStatus)
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>())
            {
                if (DemandStatusRepository.Delete(DemandStatus))
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
                //_DemandStatusRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
