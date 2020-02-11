using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGECMS.Models
{
    public class AttendanceViewModel
    {
        [Required(ErrorMessage = "Please Select Class")]
        [ForeignKey("Classes")]
        public int ClassId { get; set; }
        public virtual Classes Classes { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Assigned Date")]
        public DateTime Date { get; set; }

    }
}