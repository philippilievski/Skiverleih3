using System.ComponentModel.DataAnnotations;

namespace Skiverleih3.Model
{
    public class State
    {
        [Key]
        public int StateID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }
    }
}
