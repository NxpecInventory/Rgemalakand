using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class StudentCoursesBucket
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int Regid { get; set; }
        [Required]
        public int Studentid { get; set; }
        [Required]
        public string StudentName { get; set; }

        [Required]
        public int year { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Assigned Date")]
        public DateTime AssignedDate { get; set; }
        [Required(ErrorMessage = "Please Select the Program Of Class")]

        public int ProgramId { get; set; }
 
        [Required(ErrorMessage = "Please Select the  Class")]
        public int ClassId { get; set; }
        public string Comments { get; set; }
        public string ClassName { get; set; }
        public string ProgramName { get; set; }

    }
}