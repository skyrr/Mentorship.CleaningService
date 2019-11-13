using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public interface IAddressDbContext
    {
        DbSet<Address> Addresses { get; set; }
    }
}
