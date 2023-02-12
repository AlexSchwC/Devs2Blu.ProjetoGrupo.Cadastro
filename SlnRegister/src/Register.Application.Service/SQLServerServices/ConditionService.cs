using Register.Domain.Contracts.Repositories;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;
using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Application.Service.SQLServerServices
{
    public class ConditionService : BaseService<ConditionDTO>, IConditionService
    {
        private readonly IConditionRepository _repository;
        public ConditionService(IConditionRepository repository) 
            :base(repository)
        {
            this._repository = repository;
        }

    }
}
