

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentWebPageAPI.Models
{

    public class Student
    {
 

        public String Name { get; set; } = String.Empty;

        public String Email { get; set; } = String.Empty;

        public String CPF { get; set; } = String.Empty;

        [Key]
        public Int64 RA { get; set; }

    }
}
