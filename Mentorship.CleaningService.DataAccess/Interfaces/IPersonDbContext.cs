using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public interface IPersonDbContext
    {
        DbSet<Person> Persons { get; set; }
    }
}
