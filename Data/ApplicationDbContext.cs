using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Authorizattion_exercise.Models;
using Authorizattion_exercise.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.AccessControl;

namespace Authorizattion_exercise.Data
{
  //<User, Authorization.Role, string,IdentityUserClaim<string>, UserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>, IdentityUserToken<string>>

    
    public class ApplicationDbContext : IdentityDbContext
        
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<Contact> Contact { get; set; }
    }
}