using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractStatusController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ContractStatusController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>()) {
                return Json(ContractStatusRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>())
            {
                return Json(ContractStatusRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] ContractStatus ContractStatus)
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>())
            {
                if (ContractStatusRepository.Create(ContractStatus))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] ContractStatus ContractStatus)
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>())
            {
                if (ContractStatusRepository.Update(ContractStatus))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] ContractStatus ContractStatus)
        {
            using (var ContractStatusRepository = _factory.GetRepository<ContractStatus>())
            {
                if (ContractStatusRepository.Delete(ContractStatus))
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
                //_ContractStatusRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
