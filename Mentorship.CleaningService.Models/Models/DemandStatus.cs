﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class DemandStatus : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string StatusName { get; set; }
    }
}
