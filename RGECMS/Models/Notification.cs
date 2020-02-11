using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGECMS.Models
{
    public class Notification
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Notification Message")]
        public string NotificationMessage { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "NotificationDate Date")]
        public DateTime NotificationDate { get; set; }
        [Required]
        public string NotificationSpecific { get; set; }
    
        public string NotificationAll { get; set; }
        public string status { get; set; }
    }
}