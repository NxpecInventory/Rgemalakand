using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class regclosingcat
    {//base class for reg like here i am making registration opening closing category

        [Required]
        public int Id { get; set; }
        [Required]
        public string RegOptions { get; set; }
    }
}