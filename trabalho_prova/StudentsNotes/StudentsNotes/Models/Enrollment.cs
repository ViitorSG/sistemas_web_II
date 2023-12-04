using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentsNotes.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        public int EnrollmentYear { get; set; }

        [Required]
        public required string Status { get; set; }

        public Student? Student { get; set; }
    }
}
