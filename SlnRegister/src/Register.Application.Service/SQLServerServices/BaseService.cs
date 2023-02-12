using Abp.Domain.Repositories;
using Register.Domain.Contracts.Repositories;
using Register.Domain.Contracts.Services;
using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Application.Service.SQLServerServices
{
    public class BaseService<T> : IBaseService<T> where T:class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.GetById(id);
            return await _repository.Delete(entity);
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save(int id)
        {
            var entity = await _repository.GetById(id);
            return await _repository.Save(entity);
        }

        public Task<int> Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
