using Produto.Models;
using Microsoft.EntityFrameworkCore;

namespace Produto.context
{
    public class ProductCore : DbContext
    {
        public ProductCore(DbContextOptions<ProductCore> options) : base(options) 
        { 

        }

        public DbSet<ProdutoModel> produtos { get; set; }
    }
}

