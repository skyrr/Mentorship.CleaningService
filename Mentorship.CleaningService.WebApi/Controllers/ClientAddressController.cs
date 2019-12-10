using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class ClientAddressController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ClientAddressController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/ClientAddress/{id}")]
        public JsonResult Get(int id)
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>()) {
                return Json(ClientAddressRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/ClientAddresses")]
        public JsonResult GetAll()
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>())
            {
                return Json(ClientAddressRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/ClientAddress/create")]
        public bool Create([FromForm] ClientAddress ClientAddress)
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
        [Route("api/ClientAddress/update")]
        public bool Update([FromForm] ClientAddress ClientAddress)
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
        [Route("api/ClientAddress/delete")]
        public bool Delete([FromForm] ClientAddress ClientAddress)
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
