using Microsoft.Win32;
using StudentWebPageAPI.Models;

namespace StudentWebPageAPI.Repositories
{
    public interface IStudentRepo
    {
        Task<List<Student>> Get();
        Task<Student?> Get(int ra);
        Task<bool> Create(Student newStudent);
        Task<bool> Update(Student selected);
        Task<bool> Delete(int ra);

    }
}
