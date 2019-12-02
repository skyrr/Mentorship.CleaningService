using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _provider;
        public RepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IRepository<T> GetRepository<T>() where T : IEntity
        {
            return _provider.GetService(typeof(IRepository<T>)) as IRepository<T>;
        }
    }
}
