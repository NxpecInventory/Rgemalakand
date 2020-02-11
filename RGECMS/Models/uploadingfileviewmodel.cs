using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class uploadingfileviewmodel
    {
      
        [Required]
        public string FileDescription { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase file { get; set; }
        [Required]
        public string FileCat { get; set; }
        [Required]
        public int uploderid { get; set; }
        public string Uploadername { get; set; }
        public string filepath { get; set; }
    }
}