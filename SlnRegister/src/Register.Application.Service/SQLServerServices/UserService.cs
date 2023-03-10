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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPersonRepository _personRepository;
        public UserService(IUserRepository repository, IPersonRepository personRepository)
        {
            this._repository = repository;
            _personRepository = personRepository;
        }

        public async Task<int> Delete(int id)
        {
            var user = await _repository.GetById(id);
            return await _repository.Delete(user);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            List<UserDTO> listaDTO = new List<UserDTO>();
            foreach (var user in _repository.GetAll())
            {
                var userNewdto = new UserDTO();
                var pessoadto = new PersonDTO();

                var userdto = userNewdto.mapToDTO(user);
                userdto.person = pessoadto.mapToDTO(await _personRepository.GetById(user.PersonId));

                listaDTO.Add(userdto);
            }
            return listaDTO;
        }

        public async Task<UserDTO> GetById(int? id)
        {
            var user = new UserDTO();
            return user.mapToDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(UserDTO entity)
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
