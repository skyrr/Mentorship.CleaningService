using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class OfferStatusController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public OfferStatusController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/OfferStatus/{id}")]
        public JsonResult Get(int id)
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>()) {
                return Json(OfferStatusRepository.GetById(7));
            }          
        }

        [HttpGet]
        [Route("api/OfferStatuses")]
        public JsonResult GetAll()
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>())
            {
                return Json(OfferStatusRepository.GetAll());
            }
        }

        [HttpPost]
        [Route("api/OfferStatus/create")]
        public bool Create([FromForm] OfferStatus OfferStatus)
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>())
            {
                if (OfferStatusRepository.Create(OfferStatus))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/OfferStatus/update")]
        public bool Update([FromForm] OfferStatus OfferStatus)
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>())
            {
                if (OfferStatusRepository.Update(OfferStatus))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/OfferStatus/delete")]
        public bool Delete([FromForm] OfferStatus OfferStatus)
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>())
            {
                if (OfferStatusRepository.Delete(OfferStatus))
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
                //_OfferStatusRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
