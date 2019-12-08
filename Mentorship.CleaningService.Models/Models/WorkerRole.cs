using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class WorkerRole : IEntity
    {
        public int WorkerId { get; set; }
        public int RoleId { get; set; }
        public Worker Worker { get; set; }
        public Role Role { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
