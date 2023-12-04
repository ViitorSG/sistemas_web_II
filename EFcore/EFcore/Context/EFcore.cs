using EFcore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcore.Context
{
    public class EFcore : DbContext
    {
        public EFcore(DbContextOptions<EFcore> options) : base(options) 
        { 
        
        }
        public DbSet<ALuno> Alunos { get; set; }
    }
}
