using Microsoft.EntityFrameworkCore;
using StudentWebPageAPI.Models;
using StudentWebPageAPI.TO;

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

        public async Task<TOResponse> Create(Student newStudent)
        {
            try
            {
                TOResponse to = new TOResponse();
                to.IsSuccess = true;
                to.Message = "Aluno criado com sucesso";
                Student? baseStudent = await _context.Students.FindAsync(newStudent.RA);

                if (baseStudent != null)
                {
                    to.IsSuccess = false;
                    to.Message = "RA já cadastrado.";
                }
                if (!ValidateCPF(newStudent.CPF))
                {
                    to.IsSuccess = false;
                    to.Message = "CPF inválido.";

                }
                if (!ValidateEmail(newStudent.Email))
                {
                    to.IsSuccess = false;
                    to.Message = "E-mail inválido.";
                }
                if (!ValidateName(newStudent.Name))
                {
                    to.IsSuccess = false;
                    to.Message = "Nome incompleto. ";
                }
                if (to.IsSuccess)
                {
                    await _context.Students.AddAsync(newStudent);
                    await _context.SaveChangesAsync();
                }
                return to;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TOResponse> Update(Student student) 
        {
            try
            {
                TOResponse to = new TOResponse();
                to.IsSuccess = true;
                to.Message = "Aluno atualizado com sucesso";
                Student? baseStudent = await _context.Students.FindAsync(student.RA);

                if (baseStudent == null)
                {
                    to.IsSuccess = false;
                    to.Message = "Aluno não encontrado.";
                    return to;
                }
                if (!ValidateEmail(student.Email))
                {
                    to.IsSuccess = false;
                    to.Message = "E-mail inválido.";
                }
                if (!ValidateName(student.Name))
                {
                    to.IsSuccess = false;
                    to.Message = "Nome incompleto. ";
                }
                if (!student.Name.Equals(String.Empty))
                {
                    baseStudent.Name = student.Name;
                }
                if (!student.Email.Equals(String.Empty))
                {
                    baseStudent.Email = student.Email;
                }
                if (to.IsSuccess)
                {
                    _context.SaveChanges();
                }
                return to;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<TOResponse> Delete(int ra) 
        {
            try
            {
                TOResponse to = new TOResponse();
                to.IsSuccess = true;
                to.Message = "Aluno deletado com sucesso.";

                Student? baseStudent = await _context.Students.FindAsync(ra);
                if (baseStudent == null)
                {
                    to.IsSuccess = false;
                    to.Message = "Não foi possível deletar o aluno.";
                    return to;
                }
                _context.Students.Remove(baseStudent);
                await _context.SaveChangesAsync();

                return to;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        private bool ValidateCPF(string cpf)
        {
            var cpfToCompare = cpf.Substring(0, cpf.Length - 2);
            var times = 0;

            while (times < 2)
            {
                var temp = MapTo(cpfToCompare.ToArray());
                var tempSum = temp.Sum();

                temp.ToList().Clear();

                var remainder = tempSum % 11;
                var verifyDigit = remainder < 2 ? 0 : 11 - remainder;

                cpfToCompare = string.Concat(cpfToCompare, verifyDigit.ToString());

                times++;
            }

            return cpf == cpfToCompare;
        }

        private int[] MapTo(char[] array)
        {
            var temp = new List<int>();

            for (int i = array.Length - 1, j = 2; i >= 0; i--, j++)
            {
                var result = int.Parse(array[i].ToString()) * j;
                temp.Add(result);
            }

            return temp.ToArray();
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateName(string name) 
        {
            string[] splited = name.Split(" ");

            if (splited.Length == 1)
            {
                return false;
            }
            if (splited[0].Length < 2) 
            {
                return false;
            }
            if (splited[1].Length < 1)
            {
                return false;
            }

            return true;
        }
    }
}
