using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ContactPro.Models
{
    //app user is inheriting everything belonging to identity user
    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a max {1} characters long", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a max {1} characters long", MinimumLength = 2)]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }

        //Nav
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();


    }
}
