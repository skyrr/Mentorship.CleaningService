using System;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public interface IDbContext
    {
        DbSet<IEntity> Entity { get; set; }
    }
}
