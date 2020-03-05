using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.DTO;

namespace Mentorship.CleaningService.BusinessLogic
{
    public class CleaningServiceServiceFactory : ICleaningServiceServiceFactory
    {
        private readonly IServiceProvider _provider;
        public CleaningServiceServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public ICleaningServiceService<T> GetCleaningService<T>() where T : IEntityDTO
        {
            return _provider.GetService(typeof(ICleaningServiceService<T>)) as ICleaningServiceService<T>;
        }
    }
}
