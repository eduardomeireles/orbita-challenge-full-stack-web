using Microsoft.AspNetCore.Mvc;
using StudentWebPageAPI.TO;
using StudentWebPageAPI.Models;
using StudentWebPageAPI.Repositories;
using Microsoft.AspNetCore.Cors;

namespace StudentWebPageAPI.Controllers
{
    [EnableCors("Free")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _IStudentRepo;

        public StudentController(IStudentRepo iStudentRepo)
        {
            _IStudentRepo = iStudentRepo;
        }


        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<TOStudent>>> Get()
        {
            var students = await _IStudentRepo.Get();
            return Ok(students.Select(TOStudent.ConvertTO).ToList());
        }

        [HttpGet("Get/ra")]
        public async Task<ActionResult<IEnumerable<TOStudent>>> Get(int ra)
        {
            var students = await _IStudentRepo.Get(ra);
            if (students == null) 
            {
                return NotFound("Registro de aluno não encontrado.");
            }
            return Ok(students);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Post(Student newStudent)
        {
            var student = await _IStudentRepo.Create(newStudent);
            if (!student)
            {
                return NotFound("Registro de aluno não encontrado.");
            }
            return Ok(await _IStudentRepo.Create(newStudent));
        }


        [HttpPut("Update")]
        public async Task<ActionResult<bool>> Update(Student request)
        {
            var student = await _IStudentRepo.Update(request);
            if (!student) 
            {
                return NotFound("Registro de aluno não encontrado.");
            }
            return Ok(await _IStudentRepo.Update(request));
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete(int ra)
        {
            var student = await _IStudentRepo.Delete(ra);
            if (!student) 
            {
                return NotFound("Registro de aluno não encontrado.");
            }

            return Ok(await _IStudentRepo.Delete(ra));
        }
    }
}
