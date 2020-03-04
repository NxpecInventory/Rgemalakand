using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class CollegeEmployees
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactInfo { get; set; }
    
        public string Status { get; set; }//present or leaved
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }
        [Required(ErrorMessage = "Please Select Employee Designation")]
        [ForeignKey("employeeDesignationCategory")]
        public int DesignationId { get; set; }
        public employeeDesignationCategory employeeDesignationCategory { get; set; }//like accounts officer or peon lab etc
        public string Uploadimage { get; set; }
        [NotMapped]

        public HttpPostedFileBase ImageFile { get; set; }
    }
}