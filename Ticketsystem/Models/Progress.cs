using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketsystem.Models
{
    public class Progress
    {
        public int Id { get; set; }

        public int Order { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }
}
