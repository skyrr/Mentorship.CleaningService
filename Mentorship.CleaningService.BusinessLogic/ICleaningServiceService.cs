using Mentorship.CleaningService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.BusinessLogic
{
    public interface ICleaningServiceService<T> where T : IEntityDTO
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}
