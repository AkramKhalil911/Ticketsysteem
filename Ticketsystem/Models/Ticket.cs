using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Ticketsystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser"), Display(Name = "Customer ID")]
        public string CustomerId { get; set; }

        [ForeignKey("Application"), Display(Name = "Application ID")]
        public int ApplicationId { get; set; }
        [ForeignKey("Progress"), Display(Name = "Progress")]
        public int ProgressId { get; set; }
        [StringLength(200)]
        public string Subject { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Application Application { get; set; }
        public virtual Progress Progress { get; set; }

        public DateTime Date  { get; set; }
    }
}
