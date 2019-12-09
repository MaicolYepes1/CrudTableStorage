using Data.Interfaces;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : TableEntity, new()
    {
        private readonly CloudTableClient tableClient;
        internal CloudTable table;

        public GenericRepository(CloudTableClient tableClient, string tableName)
        {
            this.tableClient = tableClient;
            table = this.tableClient.GetTableReference(tableName);
            table.CreateIfNotExistsAsync();
        }

        public async Task Insert(T entity)
        {
            try
            {
                var operation = TableOperation.Insert(entity);
                await table.ExecuteAsync(operation);
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                var operation = TableOperation.InsertOrReplace(entity);
                await table.ExecuteAsync(operation);
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        public async Task<IEnumerable<T>> GetAll(string Query = null) 
        {
            try
            {
                TableQuery<T> tableQuery = new TableQuery<T>();
                if (!string.IsNullOrEmpty(Query))
                {
                    tableQuery = new TableQuery<T>().Where(Query);
                }

                IEnumerable<T> result = await table.ExecuteQuerySegmentedAsync(tableQuery, null);

                return result;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                IEnumerable<T> resultList = await GetAll("RowKey eq '" + id + "'");
                var entitie = resultList.SingleOrDefault();

                var operation = TableOperation.Delete(entitie);
                await table.ExecuteAsync(operation);
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }
    }
}
