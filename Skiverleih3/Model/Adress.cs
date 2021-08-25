using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skiverleih3.Model
{
    public class Adress
    {
        [Key]
        public int AdressID { get; set; }

        [Required]
        [StringLength(150)]
        public string Street { get; set; }

        [Required]
        public int Housenumber { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        [StringLength(150)]
        public string City { get; set; }

        [Required]
        [StringLength(150)]
        public string Country { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
