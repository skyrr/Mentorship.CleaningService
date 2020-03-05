using AutoMapper;
using Mentorship.CleaningService.DTO;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Mentorship.CleaningService.BusinessLogic
{
    public class AddressService : ICleaningServiceService<AddressDTO>
    {
        public IRepositoryFactory _factory;
        public IMapper _mapper;
        public AddressService(IRepositoryFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public AddressDTO CreateAdress() { return new AddressDTO(); }

        public IEnumerable<AddressDTO> GetAll() {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                try
                {
                    var address = addressRepository.GetAll();
                    IEnumerable<AddressDTO> cDTO = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressDTO>>(address);
                    return cDTO;
                }
                catch (SqlException ex)
                {
                    //TODO: Logging an exception
                    return new List<AddressDTO> { new AddressDTO { ErrorMessage = ex.Message } };
                }
                catch (Exception ex)
                {
                    //TODO: Logging an exception
                    return new List<AddressDTO> { new AddressDTO { ErrorMessage = ex.Message } };
                }
            }
        }

        //public AddressDTO GetAddressById(int id)
        //{
        //    var clientsDemand = _factory.GetRepository<Address>().GetById(id);
        //    return _mapper.Map<AddressDTO>(clientsDemand);
        //}

        public AddressDTO GetById(int id)
        {
            var clientsDemand = _factory.GetRepository<Address>().GetById(id);
            return _mapper.Map<AddressDTO>(clientsDemand);
        }

        public AddressDTO Create(AddressDTO entity)
        {
            using (var addressRepository = _factory.GetRepository<Address>())
            {
                try
                {
                    var address = _mapper.Map<Address>(entity);
                    address = addressRepository.Create(address);
                    return _mapper.Map<AddressDTO>(address);
                }
                catch (Exception ex)
                {
                    //TODO: Logging an exception
                    return  new AddressDTO { ErrorMessage = ex.Message };
                }
            }
        }

        public AddressDTO Update(AddressDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AddressDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
