using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Ticketsystem.Data;
using Ticketsystem.Models;

namespace Ticketsystem.Controllers
{
    [Authorize(Roles ="Employee")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _context = context;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Employees()
        {
            var users = await _userManager.GetUsersInRoleAsync("Employee");
            return View(users.OrderBy(u => u.LastName));
        }

        public async Task<IActionResult> Customers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Customer");
            return View(users.OrderBy(u => u.LastName));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = employee.Email,
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    Preposition = employee.Preposition,
                    LastName = employee.LastName,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, employee.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return RedirectToAction(nameof(Employees));
                }
                Errors(result);
            }
            return View(employee);
        }

        public async Task<IActionResult> Details(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            if (! IsInRole("Employee", employee))
            {
                return NotFound();
            }
            return View(employee);
        }

        public async Task<IActionResult> CustomerDetails(string id)
        {
            var customer = await _userManager.FindByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            if (!IsInRole("Customer", customer))
            {
                return NotFound();
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            if (!IsInRole("Employee", employee))
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,Preposition,LastName,PhoneNumber")] ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            var employee = await _userManager.FindByIdAsync(user.Id);

            if (employee == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employee.FirstName = user.FirstName;
                employee.Preposition = user.Preposition;
                employee.LastName = user.LastName;
                employee.PhoneNumber = user.PhoneNumber;

                var result = await _userManager.UpdateAsync(employee);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Employees));
                }
                else
                {
                    Errors(result);
                }
            }

            return View(user);
        }

        private void Errors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        private bool IsInRole(string roleName, ApplicationUser employee)
        {
            var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == employee.Id);
            var role = _context.Roles.Find(userRole.RoleId);
            return roleName == role.Name;
        }
    }    
}
