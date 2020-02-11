using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class ExpenseOutgoingRecords
    {
        [Required]
        public int Id { get; set; }//transaction id
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string TransactionType { get; set; }//includes teachers pay emloyees pay inventory including all outgoing transactions expenses details
        [Required]
        public int RecordId { get; set; }//this id is for the record of teacher salary employeeslary and invetory record outgoing
        [Required]
        public int TransactionYear { get; set; }
        [Required]
        public int TransactionAmount { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public int Personid { get; set; }

    }
}