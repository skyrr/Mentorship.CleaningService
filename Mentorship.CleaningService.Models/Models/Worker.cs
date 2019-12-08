using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class Worker : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public Person Person { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
        public virtual ICollection<WorkerRole> WorkerRoles { get; set; }
    }
}
