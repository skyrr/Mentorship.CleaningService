using Mentorship.CleaningService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.BusinessLogic
{
    public interface ICleaningServiceServiceFactory
    {
        ICleaningServiceService<T> GetCleaningService<T>() where T : IEntityDTO;
    }
}
