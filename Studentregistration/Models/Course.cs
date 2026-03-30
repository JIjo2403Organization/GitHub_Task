

using System.ComponentModel.DataAnnotations;

namespace Studentregistration.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public int Duration { get; set; }
    }
}
