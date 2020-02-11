using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class CollegeFiles
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FileDescription { get; set; }
        [Required]
        public  string filepath { get; set; }
        [Required]
        public string FileCat { get; set; }
        [Required]
        public int uploderid { get; set; }
        public string Uploadername { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Uploading Date")]
        public DateTime UploadingDate { get; set; }

    }
}