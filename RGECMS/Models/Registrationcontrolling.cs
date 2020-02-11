using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Registrationcontrolling
    {
        [Required]
        public int Id { get; set; }
        public string Comment { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Updationdate")]
        public DateTime Updationdate { get; set; }
        [Required(ErrorMessage = "Please Select the Registration action")]
        [ForeignKey("regclosingcat")]
        public int regclosingid { get; set; }
        public virtual regclosingcat regclosingcat { get; set; }
    }
}