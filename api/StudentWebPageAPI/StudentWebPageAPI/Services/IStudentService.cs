using StudentWebPageAPI.TO;
using StudentWebPageAPI.Models;

namespace StudentWebPageAPI.Services
{
    public interface IStudentService
    {
        Task<List<TOStudent>> Get();
    }
}
