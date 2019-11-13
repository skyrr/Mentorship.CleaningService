using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public interface IClientDbContext
    {
        DbSet<Client> Clients { get; set; }
    }
}
