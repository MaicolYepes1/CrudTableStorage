using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(CloudTableClient tableClient) : base(tableClient, "Person")
        {

        }
    }
}
