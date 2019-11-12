using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
    }
}
