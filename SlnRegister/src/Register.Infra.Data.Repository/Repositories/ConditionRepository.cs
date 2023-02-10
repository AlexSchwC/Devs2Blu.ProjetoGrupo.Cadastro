using Register.Domain.Contracts.Repositories;
using Register.Domain.Entities;
using Register.Infra.Data.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Infra.Data.Repository.Repositories
{
    public class ConditionRepository : BaseRepository<Condition>, IConditionRepository
    {
        private readonly SQLServerContext _context;
        public ConditionRepository(SQLServerContext context) : base(context)
        {
            this._context = context;
        }
    }
}
