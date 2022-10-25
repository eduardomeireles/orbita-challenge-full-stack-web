using System.ComponentModel.DataAnnotations;

namespace StudentWebPageAPI.Models
{
    public class Student
    {
        [Key]
        public int RA { get; set; }
        public String Name { get; set; } = String.Empty;
        public String Email { get; set; } = String.Empty;
        public String CPF { get; set; } = String.Empty;
    }
}
