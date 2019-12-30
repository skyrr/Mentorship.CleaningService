using System;
using Mentorship.CleaningService.DataAccess.Interfaces;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace Mentorship.CleaningService.DataAccess
{
    public interface IApplicationUserDbContext : IDbContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
