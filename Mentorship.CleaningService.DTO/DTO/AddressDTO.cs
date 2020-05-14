using System;

namespace Mentorship.CleaningService.DTO
{
    public class AddressDTO : IEntityDTO
    {
        public bool IsDeleted { get; set; }
        public string StreetName { get; set; } = null;
        public string BuildingNumber { get; set; } = null;
        public string ApartmentNumber { get; set; } = null;
        public string City { get; set; } = null;
        public string ErrorMessage { get; set; }
    }
}
