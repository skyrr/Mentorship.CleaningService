using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutorial.AspNetSecurity.WebClient.Models.Student;
//using Tutorial.AspNetSecurity.WebClient.DataServices;
using Microsoft.AspNetCore.Authorization;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tutorial.AspNetSecurity.WebClient.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly CleaningServiceDbContext _db;

        public StudentController(CleaningServiceDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        { 
            return View(new List<CourseGrade>());
        }
        [HttpGet]
        public IActionResult AddGrade()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGrade(Address model)
        {
            if (!ModelState.IsValid)
                return View();

            model.City = "London";

            _db.Addresses.Add(model);
            _db.SaveChanges();

            return RedirectToAction(nameof(StudentController.Index), "Student");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Classifications()
        {
            var classifications = new List<string>()
            {
                "Freshman",
                "Sophomore",
                "Junior",
                "Senior"
            };

            return View(classifications);
        }
        
    }
}
