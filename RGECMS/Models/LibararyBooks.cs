using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class LibararyBooks
    {


        [Required]
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string PublisherPlace { get; set; }
        [Required(ErrorMessage = "Please Select the Department Of Book")]
        [ForeignKey("LibararyDepCat")]
        public int DepartmentId { get; set; }
        public virtual LibararyDepCat LibararyDepCat { get; set; }
        [Required]
        public string Program { get; set; }
        [Required]
        public int Year { get; set; }
      
        [Required]
        public int Pages { get; set; }
        [Required]
        public string CallNo { get; set; }
        public string EditionVolume { get; set; }
        [Required(ErrorMessage = "Please Select the Shelf Of Book")]
        public  string Shelf { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Book Added Date")]
        public DateTime AddedDate { get; set; }



    }
}