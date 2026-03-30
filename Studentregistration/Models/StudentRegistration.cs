using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studentregistration.Models
{
    public class StudentRegistration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public long phone { get; set; }
        [Required]
        [ForeignKey("Courses")]

        public int Course_Id { get; set; }
        [Required]
        [ForeignKey("Batches")]
        public int Batch_id { get; set; }

        public virtual Course? Courses { get; set; }
        public virtual Batch? Batches { get; set; }

    }
}
