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
        public JsonResult Create([FromForm] ClientAddress clientAddress)
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>())
            {
                return Json(ClientAddressRepository.Create(clientAddress));
            }
        }

        [HttpPost]
        [Route("api/ClientAddress/update")]
        public JsonResult Update([FromForm] ClientAddress clientAddress)
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>())
            {
                return Json(ClientAddressRepository.Update(clientAddress));
            }
        }

        [HttpPost]
        [Route("api/ClientAddress/delete")]
        public bool Delete([FromForm] ClientAddress clientAddress)
        {
            using (var ClientAddressRepository = _factory.GetRepository<ClientAddress>())
            {
                return ClientAddressRepository.Delete(clientAddress);
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
