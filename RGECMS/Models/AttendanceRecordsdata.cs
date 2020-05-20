using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class AttendanceRecordsdata
    {
       [Required]
        public int Id { get; set; }
      
        [Required]
        public int Studentid { get; set; }
        [Required]
        public string Name { get; set; }
        public int ClassId { get; set; }
        public string Classname { get; set; }

   
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dataofattendance { get; set; }
        [NotMapped]
        public byte[] PrintBinary { get; set; }

        [ForeignKey("Attendanceoptions")]
        public int StatusId { get; set; }
        public virtual Attendanceoptions Attendanceoptions { get; set; }

        public string Remarks { get; set; }
     
    
    }
}