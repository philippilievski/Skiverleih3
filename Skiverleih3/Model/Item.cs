using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skiverleih3.Model
{
    class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Lendcount { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int StateID { get; set; }
        public State State { get; set; }

        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
