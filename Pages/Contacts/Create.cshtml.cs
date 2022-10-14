using Authorizattion_exercise.Authorization;
using Authorizattion_exercise.Data;
using Authorizattion_exercise.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authorizattion_exercise.Pages.Contacts
{
    public class CreateModel : DI_BasePageModel
    {
      //  private readonly Authorizattion_exercise.Data.ApplicationDbContext _context;

        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //new this is the logged in user who is making this new person entry
            Contact.OwnerID = UserManager.GetUserId(User);

            //is the person authorised to create a new person? - they can if they are logged in therefore their account is authorised
            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, Contact, ContactOperations.Create);
            
            //no! then return a 403

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            //end new  otherise add the person in.
            Context.Contact.Add(Contact);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
