using StudentWebPageAPI.Models;

namespace StudentWebPageAPI.Repositories
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAll();
        Task<bool> Create(Student newStudent);
        Task<bool> Update(Student selected);
        Task<bool> Delete(Student selected);
    }
}
