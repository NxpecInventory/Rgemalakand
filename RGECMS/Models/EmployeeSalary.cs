using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class EmployeeSalary
    {// this each recod data will be inserted into expenseoutgoing records

        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string FatherName { get; set; }

        [Required]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }
        [Required]
        public int PayingAmount { get; set; }
        public int OverTime { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public string checkNo { get; set; }

        public int GrossTotalAmount { get; set; }

        public string Recievingstatus { get; set; }



        [Required]
        public int Year { get; set; }

        public string Remarks { get; set; }

        [Required(ErrorMessage = "Please Select Employee RegNo")]
        [ForeignKey("CollegeEmployees")]
        public int EmployeeId { get; set; }
        public virtual CollegeEmployees CollegeEmployees { get; set; }
        public DateTime AddedOn { get; set; }

    }
}