using Microsoft.AspNetCore.Identity;

namespace Authorizattion_exercise.Models
{

    //these classes model a many to many relationship
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    public class UserRole : IdentityUserRole<string>
    {


        public virtual User User { get; set; }
        public virtual Role Role { get; set; }


    }

    public class ContactUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

    }

}
