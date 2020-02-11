
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGECMS.Models
{
    public class Finerecords
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public string SemesterClass { get; set; }
        [Required]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }
        [Required]
        public int FineAmount { get; set; }


        [Required]
        public int TotalAmount { get; set; }
        [Required]
        public string Payingstatus { get; set; }
        [Required]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Please Select Enrollment")]
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public virtual Students Students { get; set; }
    }
}