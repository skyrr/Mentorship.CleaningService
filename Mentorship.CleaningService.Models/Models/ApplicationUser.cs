using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models.Models
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public string Email { get; set; }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IEntity.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
