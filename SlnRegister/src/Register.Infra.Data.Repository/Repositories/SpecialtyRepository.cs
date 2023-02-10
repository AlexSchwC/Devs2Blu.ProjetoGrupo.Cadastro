using Register.Domain.Contracts.Repositories;
using Register.Domain.Entities;
using Register.Infra.Data.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Infra.Data.Repository.Repositories
{
    public class SpecialtyRepository : BaseRepository<Specialty>, ISpecialtyRepository
    {
        private readonly SQLServerContext _context;
        public SpecialtyRepository(SQLServerContext context) : base(context)
        {
            this._context = context;
        }
    }
}
