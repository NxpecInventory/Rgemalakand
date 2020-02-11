using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Teachers
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string TeacherName { get; set; }

        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactInfo { get; set; }

        public string Status { get; set; }//present or leaved and permanent or visting
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }
        [Required(ErrorMessage = "Please Select Teacher Designation")]
        [ForeignKey("teacherdesignationcategory")]
        public int DesignationId { get; set; }
        public  teacherdesignationcategory teacherdesignationcategory { get; set; } //like lecturer professor also including department
        [Required]
        public string Specialization { get; set; }

    }

}