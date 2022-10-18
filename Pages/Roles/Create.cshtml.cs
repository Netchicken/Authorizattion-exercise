using Authorizattion_exercise.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Authorizattion_exercise.Pages.Roles
{

    //@model Authorizattion_exercise.Pages.Roles.CreateModel

    public class CreateModel : PageModel
    {

        [BindProperty]
        public IdentityRole Role { get; set; }
        public RoleManager<IdentityRole> _roleManager { get; set; }

        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                
                await _roleManager.CreateAsync(Role);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
