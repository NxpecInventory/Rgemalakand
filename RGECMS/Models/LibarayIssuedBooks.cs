using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class LibarayIssuedBooks
    {
        
        [Required]
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public int BookId { get; set; }
        public string AssignedBy { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int StudedRegId { get; set; }
        public string StudentName { get; set; }
        public string StudentDepartment { get; set; }
        public string StudentClass { get; set; }
        public string Comments { get; set; }
        //received book detail will be executed when return book
        public string fineComment { get; set; }
        public string ReceivedStatus { get; set; }
        public DateTime Receiveddate { get; set; }
        public string fineslipid { get; set; }
        public string finestatus { get; set; }


    }
}