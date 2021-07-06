using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketsystem.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set;  }

        [StringLength(200)]
        public string Name { get; set; }

        [ForeignKey("Maintainer")]
        public string  MaintainerId { get; set; }
        public ApplicationUser Maintainer { get; set; }
    }
}
