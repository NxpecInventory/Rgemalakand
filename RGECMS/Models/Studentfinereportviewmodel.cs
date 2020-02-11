using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Studentfinereportviewmodel
    {
        [Required]
        public int Year { get; set; }
        [Required]
        public string Month { get; set; }
    }
}