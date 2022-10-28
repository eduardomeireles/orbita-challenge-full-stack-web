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
        public async Task<ActionResult<bool>> Post([FromBody] Student s)
        {
            TOResponse to = await _IStudentRepo.Create(s);
            if (!to.IsSuccess)
            {
                return Ok(to);
            }
            return Ok(to);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<TOResponse>> Update([FromBody] Student s)
        {
            TOResponse to = await _IStudentRepo.Update(s);
            if (!to.IsSuccess) 
            {
                return Ok(to);
            }
            return Ok(to);
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult<TOResponse>> Delete(int ra)
        {
            TOResponse to = await _IStudentRepo.Delete(ra);
            if (!to.IsSuccess) 
            {
                return Ok(to);
            }

            return Ok(to);
        }

    }
}
