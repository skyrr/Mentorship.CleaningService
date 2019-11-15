using System;

namespace Mentorship.CleaningService.Models
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}
