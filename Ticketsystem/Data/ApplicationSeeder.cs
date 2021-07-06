using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketsystem.Models;

/* Comment */

namespace Ticketsystem.Data
{
    public class ApplicationSeeder
    {
        private const string _password = "Password123!";

        private List<string> _roleNames = new List<string> { "Employee", "Customer", "Admin" };

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected async Task SeedRoles()
        {
            foreach(var roleName in _roleNames)
            {
                var exists = await _roleManager.RoleExistsAsync(roleName);
                if(! exists )
                {
                    IdentityRole role = new IdentityRole { Name = roleName };
                    await _roleManager.CreateAsync(role);
                }
            }
        }

        public async Task Seedusers()
        {
            await SeedRoles();

            var admin = new ApplicationUser
            {
                Email = "admin@ticketsystem.mbo",
                FirstName = "Administrator",
                Preposition = "of",
                LastName = "Ticketsystem",
                EmailConfirmed = true,
            };
            var user = await _userManager.FindByEmailAsync(admin.Email);
            if (user == null)
            {
                admin.UserName = admin.Email;
                var result = await _userManager.CreateAsync(admin, _password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "Admin");
                    await _userManager.AddToRoleAsync(admin, "Employee");
                }
            }
        }
    }
}
