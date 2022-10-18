using Authorizattion_exercise.Data;
using Authorizattion_exercise.Pages.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace Authorizattion_exercise.Pages.Admin
{
    public class DisplayModel : DI_BasePageModel
    {
        public DisplayModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public void OnGet()
        {
            ViewData["data"] = UserManager.Users.ToList();
            //  ViewData["moredata"] = UserManager.GetRolesAsync();
        }
    }
}
