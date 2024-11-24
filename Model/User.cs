using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login.Model
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is requires")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string? Email { get; set; }
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [Phone(ErrorMessage = "Invalid Format")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "User role required")]
        public string roleType { get; set; }

        //navigation properties

        public ICollection<Review> reviews { get; set; }
        public ICollection<Reservation> reservations { get; set; }



    }


}
