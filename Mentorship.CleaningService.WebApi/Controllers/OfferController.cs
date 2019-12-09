using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public OfferController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            using (var OfferRepository = _factory.GetRepository<Offer>()) {
                return Json(OfferRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var OfferRepository = _factory.GetRepository<Offer>())
            {
                return Json(OfferRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Offer Offer)
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
        public bool Update([FromBody] Offer Offer)
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
        public bool Delete([FromBody] Offer Offer)
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
