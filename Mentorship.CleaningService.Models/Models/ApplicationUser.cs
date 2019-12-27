using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
    }
}
