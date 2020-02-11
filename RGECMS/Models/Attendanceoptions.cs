using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Attendanceoptions
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Options { get; set; }
    }
}