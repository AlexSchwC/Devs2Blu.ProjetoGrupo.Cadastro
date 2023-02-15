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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IPersonRepository _personRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        public DoctorService(IDoctorRepository repository, IPersonRepository personRepository, ISpecialtyRepository specialtyRepository)
        {
            this._repository = repository;
            _personRepository = personRepository;
            _specialtyRepository = specialtyRepository;
        }

        public async Task<int> Delete(int id)
        {
            var doctor = await _repository.GetById(id);
            return await _repository.Delete(doctor);
        }

        public async Task<List<DoctorDTO>> GetAll()
        {
            List<DoctorDTO> listaDTO = new List<DoctorDTO>();
            foreach (var doctor in _repository.GetAll())
            {
                var doctordto = new DoctorDTO();
                var pessoadto = new PersonDTO();
                var specdto = new SpecialtyDTO();

                var docdto = doctordto.mapToDTO(doctor);
                docdto.person = pessoadto.mapToDTO(await _personRepository.GetById(doctor.PersonId));
                docdto.specialty = specdto.maptoDTO(await _specialtyRepository.GetById(doctor.SpecialtyId));

                listaDTO.Add(docdto);
            }
            return listaDTO;
        }

        public async Task<DoctorDTO> GetById(int id)
        {
            var doctor = new DoctorDTO();
            return doctor.mapToDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(DoctorDTO entity)
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
