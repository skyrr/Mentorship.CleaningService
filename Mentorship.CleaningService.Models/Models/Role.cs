using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models.Models
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string RoleName { get; set; }
    }
}
