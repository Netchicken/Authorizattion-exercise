using Authorizattion_exercise.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Authorizattion_exercise.Pages
{

    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async void OnGet()
        {
            //var model = await _context.Users
            //    .Include(x => x.UserRoles)
            //    .ThenInclude(x => x.Role)
            //    .ToListAsync();
        }
    }
}