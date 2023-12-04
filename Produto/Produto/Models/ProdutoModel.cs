using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produto.Models
{
    public class ProdutoModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string nomeProduto { get; set; }
        [Required]
        [MaxLength (150)]
        public string descricaoProduto { get; set; }
        [Required]
        public int qtdProduto { get; set; }
        [Required]
        [Column("valorDoProduto")]
        public int valorProduto { get; set;}
        [NotMapped]
        public string observacaoProduto{ get; set; }
    }
}
