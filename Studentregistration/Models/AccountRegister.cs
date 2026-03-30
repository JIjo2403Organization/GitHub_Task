using System.ComponentModel.DataAnnotations;

namespace Studentregistration.Models
{
    public class AccountRegister
    {  
            [Key]
            public int Id { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            [Display(Name = "User Name")]
            public string Username { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
            public string ConfirmPassword { get; set; }
        
    }
}
