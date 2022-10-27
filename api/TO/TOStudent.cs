using StudentWebPageAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentWebPageAPI.TO
{
    public class TOStudent
    {
        [Required]
        public int RA { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        [StringLength(11, ErrorMessage = "CPF Inválido")]
        public string CPF { get; set; } = String.Empty;


        public static TOStudent ConvertTO(Student student)
        {
            return new TOStudent
            {
                Name = student.Name,
                CPF = student.CPF,
                RA = student.RA,
                Email = student.Email,
            };
        }
    }
}
