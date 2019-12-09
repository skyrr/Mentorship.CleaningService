using System;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IRepositoryFactory _factory;

        public PersonController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            using (var PersonRepository = _factory.GetRepository<Person>()) {
                return Json(PersonRepository.GetById(7));
            }          
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            using (var PersonRepository = _factory.GetRepository<Person>())
            {
                return Json(PersonRepository.GetAll());
            }
        }

        [HttpPost]
        public bool Create([FromBody] Person Person)
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
        public bool Update([FromBody] Person Person)
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
        public bool Delete([FromBody] Person Person)
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
