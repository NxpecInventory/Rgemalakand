
using System.ComponentModel.DataAnnotations;


namespace RGECMS.Models
{
    public class collegeExpenseCategories
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string Categories { get; set; }
    }
}