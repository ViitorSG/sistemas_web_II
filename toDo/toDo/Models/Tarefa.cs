using System.ComponentModel.DataAnnotations;

namespace toDo.Models
{
    public class Tarefa
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}
