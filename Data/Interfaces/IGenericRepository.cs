using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGenericRepository<T> where T : TableEntity
    {
        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(string id);

        Task<IEnumerable<T>> GetAll(string Query = null);
    }
}
