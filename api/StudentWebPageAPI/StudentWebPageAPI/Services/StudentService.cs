using StudentWebPageAPI.TO;

namespace StudentWebPageAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentService _studentService;

        public StudentService(StudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<List<TOStudent>> GetAll() 
        {
            var test = await _studentService.GetAll();
            return test;
        }

    }
}
