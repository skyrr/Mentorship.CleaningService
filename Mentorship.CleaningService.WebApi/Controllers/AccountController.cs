using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    
    public class AccountController : Controller
    {
        private readonly ApplicationUserRepository _applicationUserRepository;

        public AccountController(ApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        [HttpPost]
        [Route("api/account/register")]
        public JsonResult Get(ApplicationUser applicationUser)
        {
            applicationUser.PasswordHash = applicationUser.PasswordHash;
            return Json(_applicationUserRepository.Create(applicationUser));
        }

        //[HttpGet]
        //[Route("api/account")]
        //public JsonResult GetAll()
        //{
        //    using (var addressRepository = _factory.GetRepository<Address>())
        //    {
        //        return Json(addressRepository.GetAll().ToList());
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_addressRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
