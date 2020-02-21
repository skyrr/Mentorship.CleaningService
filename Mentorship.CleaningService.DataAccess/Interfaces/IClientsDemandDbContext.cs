using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.DataAccess.Interfaces;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public interface IClientsDemandDbContext : IDbContext
    {
        DbSet<ClientsDemand> ClientsDemands { get; set; }
    }
}
