using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class DemandStatusController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public DemandStatusController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/DemandStatus/{id}")]

        public JsonResult Get(int id)
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>()) {
                return Json(DemandStatusRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/DemandStatuses")]
        public JsonResult GetAll()
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>())
            {
                return Json(DemandStatusRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/DemandStatus/create")]
        public JsonResult Create([FromForm] DemandStatus DemandStatus)
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>())
            {
                return Json(DemandStatusRepository.Create(DemandStatus));
            }
        }

        [HttpPost]
        [Route("api/DemandStatus/update")]
        public JsonResult Update([FromForm] DemandStatus DemandStatus)
        {
            using (var DemandStatusRepository = _factory.GetRepository<DemandStatus>())
            {
                return Json(DemandStatusRepository.Update(DemandStatus));
            }
        }

        [HttpPost]
        [Route("api/DemandStatus/delete")]
        public bool Delete([FromForm] DemandStatus DemandStatus)
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
