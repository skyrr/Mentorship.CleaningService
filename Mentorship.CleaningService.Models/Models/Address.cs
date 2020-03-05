using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mentorship.CleaningService.Models
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "The StreetName field cannot be empty!")]
        [MaxLength(50, ErrorMessage = "The StreetName cannot be so long!")]
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
