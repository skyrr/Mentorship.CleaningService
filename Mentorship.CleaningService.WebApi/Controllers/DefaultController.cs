using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        private readonly IRepository<Address> _addressRepository;
        public DefaultController()
        {
        }

        [HttpGet]
        public string Index()
        {
            return "Test";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _addressRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
