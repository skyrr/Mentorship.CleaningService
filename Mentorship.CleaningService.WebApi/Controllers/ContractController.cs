using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class ContractController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ContractController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Contract/{id}")]

        public JsonResult Get(int id)
        {
            using (var ContractRepository = _factory.GetRepository<Contract>()) {
                return Json(ContractRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/Contracts")]
        public JsonResult GetAll()
        {
            using (var ContractRepository = _factory.GetRepository<Contract>())
            {
                return Json(ContractRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/Contract/create")]
        public JsonResult Create([FromForm] Contract contract)
        {
            using (var ContractRepository = _factory.GetRepository<Contract>())
            {
                return Json(ContractRepository.Create(contract));
            }
        }

        [HttpPost]
        [Route("api/Contract/update")]
        public JsonResult Update([FromForm] Contract contract)
        {
            using (var ContractRepository = _factory.GetRepository<Contract>())
            {
                return Json(ContractRepository.Update(contract));
            }
        }

        [HttpPost]
        [Route("api/Contract/delete")]
        public bool Delete([FromForm] Contract contract)
        {
            using (var ContractRepository = _factory.GetRepository<Contract>())
            {
                return ContractRepository.Delete(contract);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_ContractRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
