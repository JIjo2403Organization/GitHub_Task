using System.ComponentModel.DataAnnotations;

namespace Studentregistration.Models
{
    public class Loging
    {
        [Required]
        [Display(Name = "User Name")]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
