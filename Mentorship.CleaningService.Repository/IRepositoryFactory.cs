using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    interface IRepositoryFactory<T> where  T : IEntity
    {
        IRepository<T> GetRepository<T>() where T : IEntity;
    }
}
