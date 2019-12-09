using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
    }
}
