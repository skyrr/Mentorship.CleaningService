using System;
using System.Dynamic;
using System.Linq;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public interface IRepository
    {
        IEntity GetById(int id);
        IQueryable<IEntity> GetAll();
        IEntity Create(IEntity entity);
        IEntity Update(IEntity entity);
        void Delete(IEntity entity);
    }
}
