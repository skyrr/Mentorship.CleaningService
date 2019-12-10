using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class WorkerRoleController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public WorkerRoleController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/WorkerRole/{id}")]
        public JsonResult Get(int id)
        {
            using (var WorkerRoleRepository = _factory.GetRepository<WorkerRole>()) {
                return Json(WorkerRoleRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/WorkerRoles")]
        public JsonResult GetAll()
        {
            using (var WorkerRoleRepository = _factory.GetRepository<WorkerRole>())
            {
                return Json(WorkerRoleRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/WorkerRole/create")]
        public bool Create([FromForm] WorkerRole WorkerRole)
        {
            using (var WorkerRoleRepository = _factory.GetRepository<WorkerRole>())
            {
                if (WorkerRoleRepository.Create(WorkerRole))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/WorkerRole/update")]
        public bool Update([FromForm] WorkerRole WorkerRole)
        {
            using (var WorkerRoleRepository = _factory.GetRepository<WorkerRole>())
            {
                if (WorkerRoleRepository.Update(WorkerRole))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/WorkerRole/delete")]
        public bool Delete([FromForm] WorkerRole WorkerRole)
        {
            using (var WorkerRoleRepository = _factory.GetRepository<WorkerRole>())
            {
                if (WorkerRoleRepository.Delete(WorkerRole))
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
                //_WorkerRoleRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
