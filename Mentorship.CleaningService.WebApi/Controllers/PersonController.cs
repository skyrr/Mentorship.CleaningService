using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public PersonController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        [Route("api/Person/{id}")]
        public JsonResult Get(int id)
        {
            using (var PersonRepository = _factory.GetRepository<Person>()) {
                return Json(PersonRepository.GetById(id));
            }          
        }

        [HttpGet]
        [Route("api/Persons")]
        public JsonResult GetAll()
        {
            using (var PersonRepository = _factory.GetRepository<Person>())
            {
                return Json(PersonRepository.GetAll().ToList());
            }
        }

        [HttpPost]
        [Route("api/Person/create")]
        public JsonResult Create( Person person)
        {
            using (var PersonRepository = _factory.GetRepository<Person>())
            {
                return Json(PersonRepository.Create(person));
            }
        }

        [HttpPost]
        [Route("api/Person/update")]
        public JsonResult Update( Person person)
        {
            using (var PersonRepository = _factory.GetRepository<Person>())
            {
                return Json(PersonRepository.Update(person));
            }
        }

        [HttpPost]
        [Route("api/Person/delete")]
        public bool Delete( Person person)
        {
            using (var PersonRepository = _factory.GetRepository<Person>())
            {
                return PersonRepository.Delete(person);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_PersonRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
