using System.ComponentModel.DataAnnotations;

namespace cadastro_fornecedores.Models
{
    public class Supplier
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string supplierFantasyName { get; set; }
        [Required]
        public string supplierEmail { get; set; }
        [Required]
        public long cnpj { get; set; }
        [Required]
        public long supplierPhone { get; set; }
        [Required]
        public string personToContact{ get; set;}        
        [Required]
        public long phoneNumberPersonToContact{ get; set;}

        [Required]
        public string supplierStreet{ get; set; }
        [Required]
        public string supplierHouseNumber { get; set; }
        [Required]
        public string supplierNeighborhood { get; set; }
        [Required]
        public string supplierCity { get; set; }
        [Required]
        public string supplierAddressComplement { get; set; }
        [Required]
        public string supplierCep{ get; set; }
        [Required]
        public string supplierState { get; set;}
    }
}
