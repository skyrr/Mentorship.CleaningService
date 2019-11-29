using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    public class RepositoryFactory : IRepositoryFactory<IEntity>
    {
        private readonly IRepository<IEntity> _entryRepository;
        public RepositoryFactory(IServiceProvider provider)
        {
            _entryRepository = provider.GetService(typeof(RepositoryFactory)) as IRepository<IEntity>;
        }
        public IRepository<T> GetRepository<T>() where T : IEntity
        {
            return (IRepository<T>) _entryRepository;
        }
    }
}
