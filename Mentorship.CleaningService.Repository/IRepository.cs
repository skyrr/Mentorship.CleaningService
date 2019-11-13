using System;
using System.Dynamic;
using System.Linq;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
