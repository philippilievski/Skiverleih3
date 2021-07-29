using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skiverleih3.Model
{
    class State
    {
        [Key]
        public int StateID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }
    }
}
