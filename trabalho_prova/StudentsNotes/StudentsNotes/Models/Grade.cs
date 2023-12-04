using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentsNotes.Models
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Discipline")]
        public int DisciplineID { get; set; }

        [Required]
        public int Score { get; set; }

        public Student? Student { get; set; }
        public Discipline? Discipline { get; set; }
    }
}
