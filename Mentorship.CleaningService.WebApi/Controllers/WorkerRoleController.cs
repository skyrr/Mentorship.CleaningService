using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerRoleController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public WorkerRoleController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            using (var WorkerRoleRepository = _factory.GetRepository<WorkerRole>()) {
                return Json(WorkerRoleRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var WorkerRoleRepository = _factory.GetRepository<WorkerRole>())
            {
                return Json(WorkerRoleRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] WorkerRole WorkerRole)
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
        public bool Update([FromBody] WorkerRole WorkerRole)
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
        public bool Delete([FromBody] WorkerRole WorkerRole)
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
