using System;
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
                return Json(OfferRepository.GetById(7));
            }          
        }

        [HttpGet]
        [Route("api/Offers")]
        public JsonResult GetAll()
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                return Json(OfferRepository.GetAll());
            }
        }

        [HttpPost]
        [Route("api/Offer/create")]
        public bool Create([FromForm] Offer Offer)
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                if (OfferRepository.Create(Offer))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/Offer/update")]
        public bool Update([FromForm] Offer Offer)
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                if (OfferRepository.Update(Offer))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/Offer/delete")]
        public bool Delete([FromForm] Offer Offer)
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                if (OfferRepository.Delete(Offer))
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
                //_OfferRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
