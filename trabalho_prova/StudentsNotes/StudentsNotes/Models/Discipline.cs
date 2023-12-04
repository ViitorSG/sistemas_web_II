using System.ComponentModel.DataAnnotations;

namespace StudentsNotes.Models
{
    public class Discipline
    {
        [Key]
        public required int DisciplineID { get; set; }

        [Required]
        public required string DisciplineName { get; set; }

        [Required]
        public required int Workload { get; set; }

        [Required]
        public required string Professor { get; set; }
    }
}
