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
            var entity = await _repository.GetById(id);
            return await _repository.Delete(entity);
        }

        public List<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save(int id)
        {
            var entity = await _repository.GetById(id);
            return await _repository.Save(entity);
        }

        public Task<int> Save<T>(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
