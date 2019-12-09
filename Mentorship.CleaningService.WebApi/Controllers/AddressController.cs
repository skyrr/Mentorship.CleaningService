using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public AddressController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            using (var addressRepository = _factory.GetRepository<Address>()) {
                return Json(addressRepository.GetById(id));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                return Json(addressRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Address address)
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
        public bool Update([FromBody] Address address)
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
        public bool Delete([FromBody] Address address)
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
