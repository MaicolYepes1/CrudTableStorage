using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTableStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await studentRepository.GetAll();

            return Ok(students);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post(Student student)
        {
            student.PartitionKey = "Student";
            student.RowKey = Guid.NewGuid().ToString();
            studentRepository.Insert(student);

            return NoContent();
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, Student student)
        {
            student.PartitionKey = "Student";
            student.RowKey = id;
            studentRepository.Update(student);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(string id)
        {
            await studentRepository.Delete(id);
            return NoContent();
        }
    }
}
