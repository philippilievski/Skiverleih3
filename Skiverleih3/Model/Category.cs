using System.ComponentModel.DataAnnotations;

namespace Skiverleih3.Model
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }
    }
}
