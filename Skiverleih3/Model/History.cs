using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skiverleih3.Model
{
    class History
    {
        [Key]
        public int HistoryID { get; set; }

        [Required]
        public DateTime LoanedOn { get; set; }
        public DateTime ReturnedOn { get; set; }

        [Required]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}
