using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public WorkerController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Worker/{id}")]
        public JsonResult Get(int id)
        {
            using (var WorkerRepository = _factory.GetRepository<Worker>()) {
                return Json(WorkerRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/Workers")]
        public JsonResult GetAll()
        {
            using (var WorkerRepository = _factory.GetRepository<Worker>())
            {
                return Json(WorkerRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/Worker/create")]
        public bool Create([FromForm] Worker Worker)
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
        [Route("api/Worker/update")]
        public bool Update([FromForm] Worker Worker)
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
        [Route("api/Worker/delete")]
        public bool Delete([FromForm] Worker Worker)
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
