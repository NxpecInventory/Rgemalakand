using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class ExpensesRecords
    {
        // this each recod data will be inserted into expenseoutgoing records
        [Required]
        public int Id { get; set; }//transaction id //challan id
        [Required]
        public string RecieverName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Paying Date")]
        public DateTime PayingDate { get; set; }
        [Required]
        public int ItemQuantity { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please Select the Expense Category")]
        [ForeignKey("collegeExpenseCategories")]
        public int CategoryId { get; set; }
        public  collegeExpenseCategories collegeExpenseCategories { get; set; }

        [Required]
        public int TransactionYear { get; set; }
        [Required]
        public int PaidAmount { get; set; }
    }
}