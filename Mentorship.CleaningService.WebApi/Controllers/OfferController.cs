using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public OfferController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Offer/{id}")]

        public JsonResult Get(int id)
        {
            using (var OfferRepository = _factory.GetRepository<Offer>()) {
                return Json(OfferRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/Offers")]
        public JsonResult GetAll()
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                return Json(OfferRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/Offer/create")]
        public JsonResult Create( Offer offer)
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                return Json(OfferRepository.Create(offer));
            }
        }

        [HttpPost]
        [Route("api/Offer/update")]
        public JsonResult Update( Offer offer)
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                return Json(OfferRepository.Update(offer));
            }
        }

        [HttpPost]
        [Route("api/Offer/delete")]
        public bool Delete( Offer offer)
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                return OfferRepository.Delete(offer);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_OfferRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
