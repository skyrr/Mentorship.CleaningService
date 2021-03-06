﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}
