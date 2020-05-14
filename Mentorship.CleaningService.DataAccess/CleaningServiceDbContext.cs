using JetBrains.Annotations;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore; IdentityDbContext

namespace Mentorship.CleaningService.DataAccess
{
    public class CleaningServiceDbContext : Microsoft.EntityFrameworkCore.DbContext,  IAddressDbContext, IClientAddressDbContext, IClientDbContext,
        ICompanyDbContext, IContractDbContext, IContractStatusDbContext, IDemandDbContext, IDemandStatusDbContext,
        IOfferDbContext, IOfferStatusDbContext, IPersonDbContext, IRoleDbContext, IServicePlanDbContext,  IWorkerDbContext, IWorkerRoleDbContext, IClientsDemandDbContext
    {
        private readonly IConfiguration _configuration;

        public CleaningServiceDbContext(DbContextOptions<CleaningServiceDbContext> options) : base(options)
        {
            //_configuration = configuration;
        }

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
        public DbSet<ClientAddress> ClientAddresses { get; set; }
        public DbSet<WorkerRole> WorkerRoles { get; set; }
        public DbSet<ClientsDemand> ClientsDemands { get; set; }

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

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.ContractStatus);
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Client);
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Company);
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.ServicePlan);

            modelBuilder.Entity<Company>()
                .HasMany(w => w.Workers);
            modelBuilder.Entity<Company>()
                .HasMany(w => w.Offers);
            modelBuilder.Entity<Company>()
                .HasMany(w => w.Contracts);

            modelBuilder.Entity<Demand>()
                .HasOne(c => c.DemandStatus);
            modelBuilder.Entity<Demand>()
                .HasOne(c => c.Client);

            modelBuilder.Entity<Offer>()
                .HasOne(c => c.OfferStatus);
            modelBuilder.Entity<Offer>()
                .HasOne(c => c.Company);

            modelBuilder.Entity<WorkerRole>()
                .HasKey(x => new { x.WorkerId, x.RoleId });
            modelBuilder.Entity<WorkerRole>()
                .HasOne(wr => wr.Worker)
                .WithMany(worker => worker.WorkerRoles)
                .HasForeignKey(wr => wr.WorkerId);
            modelBuilder.Entity<WorkerRole>()
                .HasOne(wr => wr.Role)
                .WithMany(role => role.WorkerRoles)
                .HasForeignKey(wr => wr.RoleId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
            }
        }
    }
    //required when local database deleted
    public class CleaningServiceDbContextFactory : IDesignTimeDbContextFactory<CleaningServiceDbContext>
    {
        public CleaningServiceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CleaningServiceDbContext>();
            builder.UseSqlServer("Server=localhost;Database=CleaningDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new CleaningServiceDbContext(builder.Options);
        }
    }
}
