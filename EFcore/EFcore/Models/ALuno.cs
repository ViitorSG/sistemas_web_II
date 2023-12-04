using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcore.Models
{
    public class ALuno
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        [EmailAddress]
        [Column("email_do_aluno")]
        public string Email { get; set; }
        
        [NotMapped]
        public string Observacao{ get; set; }
    }
}
