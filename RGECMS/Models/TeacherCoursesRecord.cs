using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class TeacherCoursesRecord
    {

        [Required]
        public int id { get; set; }

        [Required]
        public int Teacherid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public int Assignedprocessid { get; set; }//this is the assigned time id that is teacher course reg id
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Assigned Date")]
        public DateTime AssignedDate { get; set; }
        [Required(ErrorMessage = "Please Select the Program Of Class")]
        public int ProgramId { get; set; }
        [Required(ErrorMessage = "Please Select the  Class")]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "Please Select the Subject")]
        public int SubjectId { get; set; }
        public string ClassName { get; set; }
        public string ProgramName { get; set; }
        public string SubjectName { get; set; }

    }
}