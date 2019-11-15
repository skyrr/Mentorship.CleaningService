using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public class CleaningServiceDbContext : Microsoft.EntityFrameworkCore.DbContext, IClientDbContext, IPersonDbContext, IWorkerDbContext, IAddressDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientAddress>()
                .HasKey(x => new { x.ClientId, x.AddressId });

            modelBuilder.Entity<ClientAddress>()
                .HasOne(ca => ca.Client)
                .WithMany(client => client.ClientAddresses)
                .HasForeignKey(ca => ca.ClientId);

            modelBuilder.Entity<ClientAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(address => address.ClientAddresses)
                .HasForeignKey(ca => ca.AddressId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address);
        }
    }
}
