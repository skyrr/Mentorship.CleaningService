using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; }
    }
}
