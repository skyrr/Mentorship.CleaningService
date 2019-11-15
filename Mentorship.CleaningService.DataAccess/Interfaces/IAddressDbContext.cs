using System;
using Mentorship.CleaningService.DataAccess.Interfaces;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;


namespace Mentorship.CleaningService.DataAccess
{
    public interface IAddressDbContext : IDbContext
    {
        DbSet<Address> Addresses { get; set; }
       
    }
}
