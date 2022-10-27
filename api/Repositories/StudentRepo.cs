using Microsoft.EntityFrameworkCore;
using StudentWebPageAPI.Models;

namespace StudentWebPageAPI.Repositories
{
    public class StudentRepo : IStudentRepo 
    {
        private readonly StudentWebPageAPIContext _context;

        public StudentRepo(StudentWebPageAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> Get() 
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Student?> Get(int ra)
        {
            try
            {
                return await _context.Students.FindAsync(ra);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Create(Student newStudent)
        {
            try
            {
                await _context.Students.AddAsync(newStudent);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(Student student) 
        {
            try
            { 
                Student? baseStudent = await _context.Students.FindAsync(student.RA);

                if (baseStudent == null)
                {
                    return false;
                }
                if (!student.Name.Equals(String.Empty))
                {
                    baseStudent.Name = student.Name;
                }
                if (!student.Email.Equals(String.Empty))
                {
                    baseStudent.Email = student.Email;
                }
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<bool> Delete(int ra) 
        {
            try
            {
                Student? baseStudent = await _context.Students.FindAsync(ra);
                if (baseStudent == null)
                {
                    return false;
                }
                _context.Students.Remove(baseStudent);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
