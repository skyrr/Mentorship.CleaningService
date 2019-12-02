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

        public AddressController(IRepositoryFactory factory) //, IServiceProvider provider
        {
            _factory = factory;
            //_addressRepository = _factory.GetRepository<Address>();
        }

        [HttpGet]
        public JsonResult Get()
        {
            using (var addressRepository = _factory.GetRepository<Address>()) {
                using (var clientRepository = _factory.GetRepository<Client>()) { 
                    return Json(addressRepository.GetById(7));
                }
            }          
        }
        [HttpGet]
        //public JsonResult GetAll()
        //{
        //    return Json(_addressRepository.GetAll());
        //}

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
