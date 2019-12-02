using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<WorkerRoles> WorkerRoles{ get; set; }

    }
}
