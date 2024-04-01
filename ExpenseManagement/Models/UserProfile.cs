using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter your firstname")]
        [MinLength(3, ErrorMessage = "FirstName is too short")]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter your lasttname")]
        [MinLength(3, ErrorMessage = "LastName is too short")]
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Please enter your Email")]
        [MinLength(3, ErrorMessage = "Your email is invalid syntax")]
        [Display(Name = "Email ")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }

    }
}
