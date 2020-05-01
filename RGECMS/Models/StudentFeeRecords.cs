using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGECMS.Models
{
    public class StudentFeeRecords
    {
        [Required]
        public int Id { get; set; }
  
        public string Name { get; set; }
   
        public string FatherName { get; set; }

        public string SemesterClass { get; set; }
        [Required]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }
        [Required]
        public int  AdmissionFeeTutionFee { get; set; }
        public int HostelFee { get; set; }
        [Required]
        public int SecFee { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
  
        public int GrossTotalAmount { get; set; }

        public string Payingstatus { get; set; }
   
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }

        [Required]
        public int batch { get; set; }
        [Required]
        public string  Remarks { get; set; }

        [Required(ErrorMessage = "Please Select Enrollment")]
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public virtual Students Students { get; set; }
        public DateTime AddedOn { get; set; }




    }
}