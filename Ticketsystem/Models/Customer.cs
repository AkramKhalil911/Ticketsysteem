using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketsystem.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [StringLength(80), Required]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string Proposition { get; set; }

        [StringLength(80), Required]
        public string LastName { get; set; }

        [Required]
        public int Phonenumber { get; set; }
    }
}
