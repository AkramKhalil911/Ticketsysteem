using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ticketsystem.Models
{
    /// <summary>
    /// This class is a model for all application Users.
    /// The diffeerence between Employees and Customers is implemented in Roles.
    /// <seealso cref="IdentityUser"/>
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        // Email is a property of IdentityUser

        [Required]
        [Display(Name = "First Name")]
        [StringLength(40)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string Preposition { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(80)]
        public string LastName { get; set; }

        // PhoneNumber is a property of IdentityUser
    }
}
