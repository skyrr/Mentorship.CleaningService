using System;
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
                return Json(ClientRepository.GetById(7));
            }          
        }

        [HttpGet]
        [Route("api/Clients")]
        public JsonResult GetAll()
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                return Json(ClientRepository.GetAll());
            }
        }

        [HttpPost]
        [Route("api/Client/create")]
        public bool Create([FromForm] Client Client)
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                if (ClientRepository.Create(Client))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/Client/update")]
        public bool Update([FromForm] Client Client)
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                if (ClientRepository.Update(Client))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/Client/delete")]
        public bool Delete([FromForm] Client Client)
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                if (ClientRepository.Delete(Client))
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
                //_ClientRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
