﻿using AutoMapper;
using Mentorship.CleaningService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mentorship.CleaningService.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ClientsDemand, ClientsDemandDTO>().MaxDepth(1);
            CreateMap<Address, AddressDTO>().MaxDepth(1);
            CreateMap<ClientsDemandDTO, ClientsDemand>().MaxDepth(1);
            CreateMap<AddressDTO, Address>().MaxDepth(1);
            //CreateMap<ClientsDemandDTO, ClientsDemand>();
            //CreateMap<IEnumerable<ClientsDemand>, IEnumerable<ClientsDemandDTO>>();
            //CreateMap<IEnumerable<ClientsDemandDTO>, IEnumerable<ClientsDemand>>();
            //CreateMap<IEnumerable<ClientsDemandDTO>, IEnumerable<ClientsDemand>>();
            //CreateMap<IEnumerable<ClientsDemand>, IEnumerable<ClientsDemandDTO>>();
        }
    }
}
