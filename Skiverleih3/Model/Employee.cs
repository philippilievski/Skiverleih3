using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skiverleih3.Model
{
    class Employee
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
