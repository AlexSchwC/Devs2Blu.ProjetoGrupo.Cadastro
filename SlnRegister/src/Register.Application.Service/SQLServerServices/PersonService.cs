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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository)
        {
            this._repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var person = await _repository.GetById(id);
            return await _repository.Delete(person);
        }

        public async Task<List<PersonDTO>> GetAll()
        {
            List<PersonDTO> listaDTO = new List<PersonDTO>();
            foreach (var person in _repository.GetAll())
            {
                var persondto = new PersonDTO();
                listaDTO.Add(persondto.mapToDTO(person));
            }
           return listaDTO;
        }

        public async Task<PersonDTO> GetById(int? id)
        {
            var person = new PersonDTO();
            return person.mapToDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(PersonDTO entity)
        {
            if (entity.id > 0)
            {
                return await _repository.Update(entity.mapToEntity());
            }
            else
            {
                return await _repository.Save(entity.mapToEntity());
            }

        }
    }
}
