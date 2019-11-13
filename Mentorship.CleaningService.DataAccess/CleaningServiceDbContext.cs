using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public class CleaningServiceDbContext : Microsoft.EntityFrameworkCore.DbContext, IClientDbContext, IPersonDbContext, IWorkerDbContext, IAddressDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
