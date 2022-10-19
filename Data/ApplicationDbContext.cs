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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<User>(builder =>
        //    {

        //        builder.HasMany(u => u.UserRoles)
        //                .WithOne(ur => ur.User)
        //                .HasForeignKey(ur => ur.UserId)
        //        .IsRequired();
        //    });

        //    builder.Entity<Authorization.Role>(builder =>
        //    {

        //        builder.HasMany(r => r.UserRoles)
        //                .WithOne(ur => ur.Role)
        //                .HasForeignKey(ur => ur.RoleId)
        //                .IsRequired();

        //    });
        //}



        public DbSet<Contact> Contact { get; set; }
    }
}