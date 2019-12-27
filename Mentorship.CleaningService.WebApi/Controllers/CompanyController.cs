using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public CompanyController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Company/{id}")]
        public JsonResult Get(int id)
        {
            using (var CompanyRepository = _factory.GetRepository<Company>()) {
                return Json(CompanyRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/Companies")]
        public JsonResult GetAll()
        {
            using (var CompanyRepository = _factory.GetRepository<Company>())
            {
                return Json(CompanyRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/Company/create")]
        public JsonResult Create( Company company)
        {
            using (var CompanyRepository = _factory.GetRepository<Company>())
            {
                return Json(CompanyRepository.Create(company));
            }
        }

        [HttpPost]
        [Route("api/Company/update")]
        public JsonResult Update( Company company)
        {
            using (var CompanyRepository = _factory.GetRepository<Company>())
            {
                return Json(CompanyRepository.Update(company));
            }
        }

        [HttpPost]
        [Route("api/Company/delete")]
        public bool Delete( Company company)
        {
            using (var CompanyRepository = _factory.GetRepository<Company>())
            {
                return CompanyRepository.Delete(company);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_CompanyRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
