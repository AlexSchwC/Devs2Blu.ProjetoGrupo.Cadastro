using Microsoft.EntityFrameworkCore;
using Register.Domain.Contracts.Repositories;
using Register.Infra.Data.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Infra.Data.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SQLServerContext _sqlContext;
        public BaseRepository(SQLServerContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public Task<int> Delete(T entity)
        {
            this._sqlContext.Set<T>().Remove(entity);
            return this._sqlContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return this._sqlContext.Set<T>();
        }
        public async Task<T> GetById(int id)
        {
            return await this._sqlContext.Set<T>().FindAsync(id);
        }

        public Task<int> Save(T entity)
        {
            this._sqlContext.Set<T>().Add(entity);
            return this._sqlContext.SaveChangesAsync();
        }
        public Task<int> Update(T entity)
        {
            try
            {
                this._sqlContext.Set<T>().Update(entity);
                return this._sqlContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var text = ex.Message;
                return this._sqlContext.SaveChangesAsync();
            }
        }
        public async Task<int> ExecuteCommand(string sqlCommand)
        {
            return await this._sqlContext.Database.ExecuteSqlRawAsync(sqlCommand);
        }
    }
}
