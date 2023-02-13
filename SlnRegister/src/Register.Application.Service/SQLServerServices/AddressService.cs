using Register.Domain.Contracts.Repositories;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Application.Service.SQLServerServices
{
    public class AddressService : IAddressService
    {
            private readonly IAddressRepository _repository;
            public AddressService(IAddressRepository repository)
            {
                this._repository = repository;
            }

            public async Task<int> Delete(int id)
            {
                var address = await _repository.GetById(id);
                return await _repository.Delete(address);
            }

            public List<AddressDTO> GetAll()
            {
                List<AddressDTO> listaDTO = new List<AddressDTO>();
                foreach (var address in _repository.GetAll())
                {
                    var addressNewdto = new AddressDTO();
                    var pessoadto = new PersonDTO();

                    var addressdto = addressNewdto.mapToDTO(address);
                    addressdto.person = pessoadto.mapToDTO(address.Person);

                    listaDTO.Add(addressdto);
                }
                return listaDTO;
            }

            public async Task<AddressDTO> GetById(int id)
            {
                var address = new AddressDTO();
                return address.mapToDTO(await _repository.GetById(id));
            }

            public async Task<int> Save(AddressDTO entity)
            {
                if (entity.id > 0)
                {
                    return await _repository.Save(entity.mapToEntity());
                }
                else
                {
                    return await _repository.Update(entity.mapToEntity());
                }

            }
        }
}
