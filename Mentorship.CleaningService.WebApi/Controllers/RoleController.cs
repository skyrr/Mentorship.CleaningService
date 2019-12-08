using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public RoleController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get([FromBody] Role Role)
        {
            using (var RoleRepository = _factory.GetRepository<Role>()) {
                return Json(RoleRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var RoleRepository = _factory.GetRepository<Role>())
            {
                return Json(RoleRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Role Role)
        {
            using (var RoleRepository = _factory.GetRepository<Role>())
            {
                if (RoleRepository.Create(Role))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] Role Role)
        {
            using (var RoleRepository = _factory.GetRepository<Role>())
            {
                if (RoleRepository.Update(Role))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] Role Role)
        {
            using (var RoleRepository = _factory.GetRepository<Role>())
            {
                if (RoleRepository.Delete(Role))
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
                //_RoleRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
