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
        public bool Create([FromForm] Person Person)
        {
            using (var PersonRepository = _factory.GetRepository<Person>())
            {
                if (PersonRepository.Create(Person))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/Person/update")]
        public bool Update([FromForm] Person Person)
        {
            using (var PersonRepository = _factory.GetRepository<Person>())
            {
                if (PersonRepository.Update(Person))
                {
                    return true;
                }
                else return false;
            }
        }

        [HttpPost]
        [Route("api/Person/delete")]
        public bool Delete([FromForm] Person Person)
        {
            using (var PersonRepository = _factory.GetRepository<Person>())
            {
                if (PersonRepository.Delete(Person))
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
                //_PersonRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
