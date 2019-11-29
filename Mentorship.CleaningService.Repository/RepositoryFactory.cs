using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    public class RepositoryFactory : IRepositoryFactory<IEntity>
    {
        private readonly IRepositoryFactory<IEntity> _entryRepository;
        public RepositoryFactory(IServiceProvider provider)
        {
            _entryRepository = provider.GetService(typeof(RepositoryFactory)) as IRepositoryFactory<IEntity>;
        }
        public IRepository<IEntity> GetRepository<T>() where T : IEntity
        {
            return (IRepository<IEntity>)_entryRepository;
        }
    }
}
