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
    public class DetailsModel : PageModel
    {
        private readonly Authorizattion_exercise.Data.ApplicationDbContext _context;

        public DetailsModel(Authorizattion_exercise.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }
            else 
            {
                Contact = contact;
            }
            return Page();
        }
    }
}
