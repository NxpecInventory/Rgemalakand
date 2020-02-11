using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Classes
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "Please Select the Program Of Class")]
        [ForeignKey("Program")]
        public int ProgramId { get; set; }
        public virtual  Programs Program { get; set; }
    }
}