using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public ContractController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get([FromBody] Contract Contract)
        {
            using (var ContractRepository = _factory.GetRepository<Contract>()) {
                return Json(ContractRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var ContractRepository = _factory.GetRepository<Contract>())
            {
                return Json(ContractRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Contract Contract)
        {
            using (var ContractRepository = _factory.GetRepository<Contract>())
            {
                if (ContractRepository.Create(Contract))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Update([FromBody] Contract Contract)
        {
            using (var ContractRepository = _factory.GetRepository<Contract>())
            {
                if (ContractRepository.Update(Contract))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] Contract Contract)
        {
            using (var ContractRepository = _factory.GetRepository<Contract>())
            {
                if (ContractRepository.Delete(Contract))
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
                //_ContractRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
