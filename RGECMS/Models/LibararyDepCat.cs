using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class LibararyDepCat
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
      
        public string Description { get; set; }

    }
}