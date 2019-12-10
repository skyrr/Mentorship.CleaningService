using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public AddressController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/address/{id}")]
        public JsonResult Get(int id)
        {
            using (var addressRepository = _factory.GetRepository<Address>()) {
                return Json(addressRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/addresses")]
        public JsonResult GetAll()
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                return Json(addressRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/address/create")]
        public bool Create([FromForm] Address address)
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                if (addressRepository.Create(address))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/address/update")]
        public bool Update([FromForm] Address address)
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                if (addressRepository.Update(address))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/address/delete")]
        public bool Delete([FromForm] Address address)
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                if (addressRepository.Delete(address))
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
                //_addressRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
