using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    public interface IRepositoryFactory<T> where  T : IEntity
    {
        IRepository<IEntity> GetRepository<T>() where T : IEntity;
    }
}
