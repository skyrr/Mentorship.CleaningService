﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class ClientAddress : IEntity
    {
        public int AddressId { get; set; }
        public int ClientId { get; set; }
    }
}
