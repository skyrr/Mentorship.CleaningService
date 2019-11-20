using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public class CleaningServiceDbContext : Microsoft.EntityFrameworkCore.DbContext, IClientDbContext, IPersonDbContext, IWorkerDbContext, 
        IAddressDbContext, ICompanyDbContext, IContractDbContext, IContractStatusDbContext, IDemandDbContext, IDemandStatusDbContext,
        IOfferDbContext, IOfferStatusDbContext, IRoleDbContext, IServicePlanDbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<DemandStatus> DemandStatuses { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferStatus> OfferStatuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ServicePlan> ServicePlans { get; set; }

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
