using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ClientController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Client/{id}")]
        public JsonResult Get(int id)
        {
            using (var ClientRepository = _factory.GetRepository<Client>()) {
                return Json(ClientRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/Clients")]
        public JsonResult GetAll()
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                return Json(ClientRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/Client/create")]
        public JsonResult Create([FromForm] Client client)
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                return Json(ClientRepository.Create(client));
            }
        }

        [HttpPost]
        [Route("api/Client/update")]
        public JsonResult Update([FromForm] Client client)
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                return Json(ClientRepository.Update(client));
            }
        }

        [HttpPost]
        [Route("api/Client/delete")]
        public bool Delete([FromForm] Client client)
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                return ClientRepository.Delete(client);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_ClientRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
