using System.ComponentModel.DataAnnotations;

namespace Skiverleih3.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(150)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(150)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(150)]
        public string Username { get; set; }

        [Required]
        [StringLength(150)]
        public string PasswordHash { get; set; }
    }
}
