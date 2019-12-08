using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public WorkerController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get([FromBody] Worker Worker)
        {
            using (var WorkerRepository = _factory.GetRepository<Worker>()) {
                return Json(WorkerRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var WorkerRepository = _factory.GetRepository<Worker>())
            {
                return Json(WorkerRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Worker Worker)
        {
            using (var WorkerRepository = _factory.GetRepository<Worker>())
            {
                if (WorkerRepository.Create(Worker))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] Worker Worker)
        {
            using (var WorkerRepository = _factory.GetRepository<Worker>())
            {
                if (WorkerRepository.Update(Worker))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] Worker Worker)
        {
            using (var WorkerRepository = _factory.GetRepository<Worker>())
            {
                if (WorkerRepository.Delete(Worker))
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
                //_WorkerRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
