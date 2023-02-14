using Register.Domain.Contracts.Repositories;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;
using Register.Domain.Entities;
using Register.Infra.Data.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Application.Service.SQLServerServices
{
    public class ConditionService : IConditionService
    {
        private readonly IConditionRepository _repository;
        public ConditionService(IConditionRepository repository) 
        {
            this._repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var condition = await _repository.GetById(id);
            return await _repository.Delete(condition);
        }

        public async Task<List<ConditionDTO>> GetAll()
        {
            return _repository.GetAll().Select(c => new ConditionDTO()
            {
                id = c.Id,
                name = c.Name,
            }).ToList();
        }

        public async Task<ConditionDTO> GetById(int id)
        {
            var cond = new ConditionDTO();
            return cond.maptoDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(ConditionDTO entity)
        {
            if(entity.id > 0)
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
