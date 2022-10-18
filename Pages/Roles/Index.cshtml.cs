using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Authorizattion_exercise.Pages.Roles
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<IdentityRole> Roles { get; set; }
        public RoleManager<IdentityRole> _roleManager { get; set; }

        public IndexModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public void OnGet()
        {
            Roles = _roleManager.Roles.ToList();
            

        }
    }
}
