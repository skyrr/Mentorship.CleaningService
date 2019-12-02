using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : IEntity;
    }
}
