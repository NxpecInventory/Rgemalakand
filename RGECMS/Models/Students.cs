using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Students
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }

        [Required]
        public string GuardianName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactInfo { get; set; }
      
        public string Status { get; set; }//present graduated leaves sppeeled etc
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joining Date")]
        public DateTime AddmissionDate { get; set; }

        //[Required(ErrorMessage = "Please Select Class")]
        //[ForeignKey("Classes")]
        //public int ClassId { get; set; }
        //public virtual  Classes Classes { get; set; }
        public int ClassId { get; set; }// its is for current semester and class and it will be updating continoulsy on each registaration
        [Required(ErrorMessage = "Please Select the Program Of Class")]
        [ForeignKey("Programs")]
        public int ProgramId { get; set; }
        public virtual Programs Programs { get; set; }
        public string CurrentSemclass { get; set; }
      
        public string Uploadimage { get; set; }
        [NotMapped]

        public HttpPostedFileBase ImageFile { get; set; }
        public DateTime AddedOn { get; set; }

    }
}