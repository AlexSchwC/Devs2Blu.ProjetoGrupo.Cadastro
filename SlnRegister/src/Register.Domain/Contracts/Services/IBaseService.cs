using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Domain.Contracts.Services
{
    public interface IBaseService
    {
        List<T> GetAll<T>();
        Task<T> GetById<T>(int id);
        Task<int> Save<T>(T entity);
        Task<int> Delete(int id);
    }
}
