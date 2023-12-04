using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsNotes.Models
{
    public class Student
    {
        [Key]
        public required int StudentID { get; set; }

        [Required]
        public required string StudentName { get; set; }

        [Required]
        public required int StudentAge { get; set; }

        [EmailAddress(ErrorMessage = "O formato do e-mail não é válido.")]
        public required string Email { get; set; }

        [Required]
        public required string Telefone { get; set; }

        public required bool HasNotebook { get; set; }
    }
}
