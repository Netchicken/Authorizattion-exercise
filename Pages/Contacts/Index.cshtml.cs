using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Authorizattion_exercise.Data;
using Authorizattion_exercise.Models;

namespace Authorizattion_exercise.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly Authorizattion_exercise.Data.ApplicationDbContext _context;

        public IndexModel(Authorizattion_exercise.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contact != null)
            {
                Contact = await _context.Contact.ToListAsync();
            }
        }
    }
}
