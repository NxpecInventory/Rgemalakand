using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class StudentClassAssigningSystem
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int Studentid { get; set; }

        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string ProgramName { get; set; }

        public int year { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Assigned Date")]
        public DateTime AssignedDate { get; set; }
        [Required(ErrorMessage = "Please Select the Program Of Class")]
        [ForeignKey("Program")]
        public int ProgramId { get; set; }
        public virtual Programs Program { get; set; }
        [Required(ErrorMessage = "Please Select the  Class")]
        public int ClassId { get; set; }

        public string Comments { get; set; }

    }
}