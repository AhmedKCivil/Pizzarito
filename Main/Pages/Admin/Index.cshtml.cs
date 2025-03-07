using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaritoShop.Data;

namespace PizzaritoShop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        //        private readonly UserManager<ApplicationUser> _userManager;

        //        public IndexModel(UserManager<ApplicationUser> userManager)
        //        {
        //            _userManager = userManager;
        //        }

        //        [BindProperty]
        //        public string SelectedUserId { get; set; }
        //        [BindProperty]
        //        public string SelectedRole { get; set; }
        //        public List<ApplicationUser> Users { get; set; }

        //        public async Task OnGetAsync()
        //        {
        //            Users = await _userManager.Users.ToListAsync();
        //        }

        //        public async Task<IActionResult> OnPostAsync()
        //        {
        //            if (string.IsNullOrEmpty(SelectedUserId) || string.IsNullOrEmpty(SelectedRole))
        //            {
        //                ModelState.AddModelError(string.Empty, "User or role cannot be empty.");
        //                return Page();
        //            }

        //            var user = await _userManager.FindByIdAsync(SelectedUserId);
        //            if (user != null)
        //            {
        //                await _userManager.AddToRoleAsync(user, SelectedRole);
        //            }

        //            return RedirectToPage("/Admin/Index");
        //        }
        //    }
    }
}
