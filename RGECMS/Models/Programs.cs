using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace RGECMS.Models
{//this is my programs model class
    public class Programs
    {   [Required]
        public int Id { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Program Start Date")]
        public DateTime ProgramStartingDate { get; set; }

    }
}