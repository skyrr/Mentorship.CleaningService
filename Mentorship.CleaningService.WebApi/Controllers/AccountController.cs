using System;
using System.Linq;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [ApiController]
    
    public class AccountController : Controller
    {
        // private readonly ApplicationUserRepository _applicationUserRepository;

        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)//ApplicationUserRepository applicationUserRepository
        {
            //_applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("api/account/register")]
        public async System.Threading.Tasks.Task<IdentityResult> CreateAsync(ApplicationUser applicationUser)
        {
            //applicationUser.PasswordHash = applicationUser.PasswordHash;
            //return Json(_applicationUserRepository.Create(applicationUser));
            IdentityUser user = new IdentityUser()
            {
                Email = applicationUser.Email,
                UserName = applicationUser.Email
            };

            var result = await _userManager.CreateAsync(user, applicationUser.PasswordHash);
            return result;
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
