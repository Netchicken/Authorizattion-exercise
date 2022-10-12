using Authorizattion_exercise.Authorization;
using Authorizattion_exercise.Data;
using Authorizattion_exercise.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authorizattion_exercise.Pages.Contacts
{
    public class DetailsModel : DI_BasePageModel
    {
        private readonly Authorizattion_exercise.Data.ApplicationDbContext _context;

        public DetailsModel(
           ApplicationDbContext context,
           IAuthorizationService authorizationService,
           UserManager<IdentityUser> userManager)
           : base(context, authorizationService, userManager)
        {
        }
        [BindProperty]
        public Contact Contact { get; set; }



        public async Task<IActionResult> OnPostAsync(int id, ContactStatus status)
        {
            var contact = await Context.Contact.FirstOrDefaultAsync(
                                                      m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            var contactOperation = (status == ContactStatus.Approved)
                                                       ? ContactOperations.Approve
                                                       : ContactOperations.Reject;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, contact,
                                        contactOperation);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            contact.Status = status;
            Context.Contact.Update(contact);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null || _context.Contact == null)
        //    {
        //        return NotFound();
        //    }

        //    var contact = await _context.Contact.FirstOrDefaultAsync(m => m.ContactId == id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }
        //    else 
        //    {
        //        Contact = contact;
        //    }
        //    return Page();
        //}
    }
}
