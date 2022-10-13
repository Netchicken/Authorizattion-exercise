using Authorizattion_exercise.Authorization;
using Authorizattion_exercise.Data;
using Authorizattion_exercise.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authorizattion_exercise.Pages.Contacts
{

    
    public class IndexModel : DI_BasePageModel
    {

        public IndexModel(
           ApplicationDbContext context,
           IAuthorizationService authorizationService,
           UserManager<IdentityUser> userManager)
           : base(context, authorizationService, userManager)
        {
        }
        
        public IList<Contact> Contact { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Contact != null)
            //{
            // Contact = await _context.Contact.ToListAsync();


            var contacts = from c in Context.Contact
                           select c;

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
                               User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner.
            if (!isAuthorized)
            {
                contacts = contacts.Where(c => c.Status == ContactStatus.Approved
                                            || c.OwnerID == currentUserId);
            }

            Contact = await contacts.ToListAsync();

            
        }
    }
}
