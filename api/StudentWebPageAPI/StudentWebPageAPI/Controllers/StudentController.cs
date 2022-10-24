using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace StudentWebPageAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Models.Student> students = new List<Models.Student>
        {
            new Models.Student {
                Name = "aluno 1",
                Email = "email@teste.com",
                CPF = "00000000000",
                RA = 1
            },
            new Models.Student {
                Name = "aluno 2",
                Email = "email@teste.com",
                CPF = "00000000000",
                RA = 2
            }

        };

        [HttpGet]
        public async Task<ActionResult<List<Models.Student>>> Get() 
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Models.Student>>> GetById(int id)
        {
            var student = students.Find(s => s.RA == id);
            if (student == null) 
            {
                return BadRequest("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<Models.Student>>> Post([FromBody] Models.Student newStudent)
        {
            students.Add(newStudent);
            return Ok(students);
        }


        [HttpPut]
        public async Task<ActionResult<List<Models.Student>>> UpdateStudent([FromBody] Models.Student request)
        {
            var student = students.Find(s => s.RA == request.RA);
            if (student == null)
            {
                return BadRequest("Student not found.");
            }

            student.Name = request.Name;
            student.Email = request.Email;

            return Ok(student);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Models.Student>>> Delete(int id)
        {
            var student = students.Find(s => s.RA == id);
            if (student == null)
            {
                return BadRequest("Student not found.");
            }

            students.Remove(student);

            return Ok(students);
        }
    }
}
