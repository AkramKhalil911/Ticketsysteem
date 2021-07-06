using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticketsystem.Models;

namespace Ticketsystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Ticket> Date  { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<Ticketsystem.Models.Customer> Customer { get; set; }
    }
}
