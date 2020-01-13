using System;
using Mentorship.CleaningService.DataAccess.Interfaces;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mentorship.CleaningService.DataAccess
{
    public class ApplicationUserDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        private readonly IConfiguration _configuration;

        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
            }
        }
    }
}
