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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IPersonRepository _personRepository;
        private readonly IConditionRepository _conditionRepository;
        public PatientService(IPatientRepository repository, IPersonRepository personRepository, IConditionRepository conditionRepository)
        {
            this._repository = repository;
            _personRepository = personRepository;
            _conditionRepository = conditionRepository;
        }

        public async Task<int> Delete(int id)
        {
            var patient = await _repository.GetById(id);
            return await _repository.Delete(patient);
        }

        public async Task<List<PatientDTO>> GetAll()
        {
            List<PatientDTO> listaDTO = new List<PatientDTO>();
            var listaRepository = _repository.GetAll();
            foreach (var patient in listaRepository)
            {
                var patientdto = new PatientDTO();
                var pessoadto = new PersonDTO();
                var conddto = new ConditionDTO();

                var patdto = patientdto.mapToDTO(patient);
                patdto.person = pessoadto.mapToDTO(await _personRepository.GetById(patient.PersonId));
                patdto.condition = conddto.maptoDTO(await _conditionRepository.GetById(patient.ConditionId));

                listaDTO.Add(patdto);
            }
            return listaDTO;
        }

        public async Task<PatientDTO> GetById(int? id)
        {
            var patient = new PatientDTO();
            return patient.mapToDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(PatientDTO entity)
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
