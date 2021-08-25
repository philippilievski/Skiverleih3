using System;
using System.ComponentModel.DataAnnotations;

namespace Skiverleih3.Model
{
    public class History
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
