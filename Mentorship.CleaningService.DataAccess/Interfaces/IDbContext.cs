using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mentorship.CleaningService.DataAccess.Interfaces
{
    public interface IDbContext : IDisposable
    {
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
