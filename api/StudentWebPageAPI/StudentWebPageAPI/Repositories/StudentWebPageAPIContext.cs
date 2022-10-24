using Microsoft.EntityFrameworkCore;
using StudentWebPageAPI.Models;

namespace StudentWebPageAPI.Repositories
{
    public class StudentWebPageAPIContext : DbContext
    {

        public StudentWebPageAPIContext(DbContextOptions<StudentWebPageAPIContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; } = null!;
    }
}
