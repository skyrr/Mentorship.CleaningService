using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public RoleController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Role/{id}")]
        public JsonResult Get(int id)
        {
            using (var RoleRepository = _factory.GetRepository<Role>()) {
                return Json(RoleRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/Roles")]
        public JsonResult GetAll()
        {
            using (var RoleRepository = _factory.GetRepository<Role>())
            {
                return Json(RoleRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/Role/create")]
        public JsonResult Create([FromForm] Role Role)
        {
            using (var RoleRepository = _factory.GetRepository<Role>())
            {
                return Json(RoleRepository.Create(Role));
            }
        }

        [HttpPost]
        [Route("api/Role/update")]
        public JsonResult Update([FromForm] Role Role)
        {
            using (var RoleRepository = _factory.GetRepository<Role>())
            {
                return Json(RoleRepository.Update(Role));
            }
        }

        [HttpPost]
        [Route("api/Role/delete")]
        public bool Delete([FromForm] Role Role)
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
