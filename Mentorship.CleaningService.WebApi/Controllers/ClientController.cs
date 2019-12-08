using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ClientController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get([FromBody] Client Client)
        {
            using (var ClientRepository = _factory.GetRepository<Client>()) {
                return Json(ClientRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var ClientRepository = _factory.GetRepository<Client>())
            {
                return Json(ClientRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Client Client)
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
        public bool Update([FromBody] Client Client)
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
        public bool Delete([FromBody] Client Client)
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
