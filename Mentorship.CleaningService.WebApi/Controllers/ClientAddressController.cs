using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAddressController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ClientAddressController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get([FromBody] ClientAddress ClientAddress)
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>()) {
                return Json(ClientAddressRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>())
            {
                return Json(ClientAddressRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] ClientAddress ClientAddress)
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>())
            {
                if (ClientAddressRepository.Create(ClientAddress))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] ClientAddress ClientAddress)
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>())
            {
                if (ClientAddressRepository.Update(ClientAddress))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] ClientAddress ClientAddress)
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>())
            {
                if (ClientAddressRepository.Delete(ClientAddress))
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
                //_ClientAddressRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
