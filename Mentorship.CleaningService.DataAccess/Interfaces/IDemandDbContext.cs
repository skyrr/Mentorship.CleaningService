﻿using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.DataAccess.Interfaces;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.DataAccess
{
    public interface IDemandDbContext : IDbContext
    {
        DbSet<Demand> Demands { get; set; }
    }
}
