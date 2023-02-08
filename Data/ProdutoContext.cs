using Automatic_migrations.Models;
using Microsoft.EntityFrameworkCore;

namespace Automatic_migrations.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {

        }
        
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(builder => 
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Descricao).HasMaxLength(50);
            });
        }
    }
}