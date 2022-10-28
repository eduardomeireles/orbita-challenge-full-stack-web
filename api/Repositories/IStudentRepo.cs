using StudentWebPageAPI.Models;
using StudentWebPageAPI.TO;

namespace StudentWebPageAPI.Repositories
{
    public interface IStudentRepo
    {
        Task<List<Student>> Get();
        Task<Student?> Get(int ra);
        Task<TOResponse> Create(Student newStudent);
        Task<TOResponse> Update(Student selected);
        Task<TOResponse> Delete(int ra);

    }
}
