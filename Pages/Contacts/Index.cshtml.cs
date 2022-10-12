using Authorizattion_exercise.Data;
using Authorizattion_exercise.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authorizattion_exercise.Pages.Contacts
{
    [AllowAnonymous]
    public class IndexModel : DI_BasePageModel
    {
        private readonly Authorizattion_exercise.Data.ApplicationDbContext _context;

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
            if (_context.Contact != null)
            {
                Contact = await _context.Contact.ToListAsync();
            }
        }
    }
}
