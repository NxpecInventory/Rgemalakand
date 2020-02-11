using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Subjects
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }

        [Required(ErrorMessage = "Please Select Class")]
        [ForeignKey("Classes")]
        public int ClassId { get; set; }
        public virtual Classes Classes { get; set; }

    }
}