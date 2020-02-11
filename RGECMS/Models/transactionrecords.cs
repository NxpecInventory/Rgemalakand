using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RGECMS.Models
{
    public class transactionrecords
    {
        [Required]
        public int Id { get; set; }//transaction id
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string TransactionType { get; set; }//includes fees fines teachers pay expenses details
        [Required]
        public int PersonId { get; set; }//person id
        [Required]
        public int TransactionYear { get; set; }
        [Required]
        public int TransactionAmount { get; set; }
    }
}