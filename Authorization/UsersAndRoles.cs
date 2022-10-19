using Microsoft.AspNetCore.Identity;

namespace Authorizattion_exercise.Authorization
{

    //these classes model a many to many relationship
    public class User:IdentityUser
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
     public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    public class UserRole : IdentityUserRole<string> {


        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        

    }

   
}
