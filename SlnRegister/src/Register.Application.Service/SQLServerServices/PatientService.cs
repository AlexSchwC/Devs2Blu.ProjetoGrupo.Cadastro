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
        public PatientService(IPatientRepository repository)
        {
            this._repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var patient = await _repository.GetById(id);
            return await _repository.Delete(patient);
        }

        public List<PatientDTO> GetAll()
        {
            List<PatientDTO> listaDTO = new List<PatientDTO>();
            foreach (var patient in _repository.GetAll())
            {
                var patientdto = new PatientDTO();
                var pessoadto = new PersonDTO();

                var patdto = patientdto.mapToDTO(patient);
                patdto.person = pessoadto.mapToDTO(patient.Person);

                listaDTO.Add(patdto);
            }
            return listaDTO;
        }

        public async Task<PatientDTO> GetById(int id)
        {
            var patient = new PatientDTO();
            return patient.mapToDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(PatientDTO entity)
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
