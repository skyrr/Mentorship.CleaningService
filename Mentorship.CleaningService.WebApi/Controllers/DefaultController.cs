using System;
using System.Web.Http;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;

namespace Mentorship.CleaningService.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly IRepository<Address> _addressRepository;
        public DefaultController(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        [HttpGet]
        public void Index()
        {
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
