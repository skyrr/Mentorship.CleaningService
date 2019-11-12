using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class Worker : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }

    }
}
