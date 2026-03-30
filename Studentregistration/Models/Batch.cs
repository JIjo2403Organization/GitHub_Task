using System.ComponentModel.DataAnnotations;

namespace Studentregistration.Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? BatchName { get; set; }
        [Required]
        public string? Year { get; set; }
    }
}
