using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skiverleih3.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        public int Telephonenumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Adress Adress { get; set; }
        public int AdressID { get; set; }

        public List<Item> Items { get; set; }
    }
}
