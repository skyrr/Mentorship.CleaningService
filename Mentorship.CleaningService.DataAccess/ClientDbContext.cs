using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}
