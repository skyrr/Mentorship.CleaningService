using System;
using System.Linq;
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
                return Json(OfferStatusRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/OfferStatuses")]
        public JsonResult GetAll()
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>())
            {
                return Json(OfferStatusRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/OfferStatus/create")]
        public JsonResult Create([FromForm] OfferStatus offerStatus)
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>())
            {
                return Json(OfferStatusRepository.Create(offerStatus));
            }
        }

        [HttpPost]
        [Route("api/OfferStatus/update")]
        public JsonResult Update([FromForm] OfferStatus offerStatus)
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>())
            {
                return Json(OfferStatusRepository.Update(offerStatus));
            }
        }

        [HttpPost]
        [Route("api/OfferStatus/delete")]
        public bool Delete([FromForm] OfferStatus offerStatus)
        {
            using (var OfferStatusRepository = _factory.GetRepository<OfferStatus>())
            {
                return OfferStatusRepository.Delete(offerStatus);
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
