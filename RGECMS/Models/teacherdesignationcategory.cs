using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class teacherdesignationcategory
    {// updated this as a teacher department like medical eng etc 

        [Required]
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}