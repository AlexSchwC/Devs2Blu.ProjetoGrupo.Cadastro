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
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository _repository;
        public SpecialtyService(ISpecialtyRepository repository)
        {
            this._repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var specialty = await _repository.GetById(id);
            return await _repository.Delete(specialty);
        }

        public async Task<List<SpecialtyDTO>> GetAll()
        {
            return _repository.GetAll().Select(c => new SpecialtyDTO()
            {
                id = c.Id,
                name = c.Name,
            }).ToList();
        }

        public async Task<SpecialtyDTO> GetById(int id)
        {
            var spe = new SpecialtyDTO();
            return spe.maptoDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(SpecialtyDTO entity)
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
