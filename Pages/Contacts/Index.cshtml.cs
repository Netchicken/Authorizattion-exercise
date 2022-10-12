using Authorizattion_exercise.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Authorizattion_exercise.Pages.Contacts
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly Authorizattion_exercise.Data.ApplicationDbContext _context;

        public IndexModel(Authorizattion_exercise.Data.ApplicationDbContext context)
        {
            _context = context;
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
