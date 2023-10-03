using cadastro_fornecedores.Models;
using Microsoft.EntityFrameworkCore;

namespace cadastro_fornecedores.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
