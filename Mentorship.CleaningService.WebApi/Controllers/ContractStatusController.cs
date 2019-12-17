using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class ContractStatusController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ContractStatusController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/ContractStatus/{id}")]

        public JsonResult Get(int id)
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>()) {
                return Json(ContractStatusRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/ContractStatuses")]
        public JsonResult GetAll()
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>())
            {
                return Json(ContractStatusRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/ContractStatus/create")]
        public JsonResult Create([FromForm] ContractStatus contractStatus)
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>())
            {
                return Json(ContractStatusRepository.Create(contractStatus));
            }
        }

        [HttpPost]
        [Route("api/ContractStatus/update")]
        public JsonResult Update([FromForm] ContractStatus contractStatus)
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>())
            {
                return Json(ContractStatusRepository.Update(contractStatus));
            }
        }

        [HttpPost]
        [Route("api/ContractStatus/delete")]
        public bool Delete([FromForm] ContractStatus contractStatus)
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>())
            {
                return ContractStatusRepository.Delete(contractStatus);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_ContractStatusRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
