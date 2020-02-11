using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Publicmessages
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string phoneno { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [DataType(DataType.Text)]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Submission Date")]

        public DateTime MessageDate { get; set; }

        public string status { get; set; }//i will use it as a read or unread messages flag it should be onlu read or unread hard coded

    }
}