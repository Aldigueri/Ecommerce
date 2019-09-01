using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;




namespace Ecommerce.Context
{
    public class EcommerceContext : DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Revendedor> Revendedores { get; set; }
        public DbSet<HistoricoCompras> Compras { get; set; }
        public DbSet<Parceria> Parceiros { get; set; }

        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }

        public EcommerceContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                         .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Ecommerce;Trusted_Connection=true;");
            }

        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<HistoricoCompras>()
        //        .HasMany(ml => ml.Produtos)
        //        .WithMany(m => m.Compras)
        //        .HasForeignKey(ml => ml.ProdutoId)
        //        .OnDelete(DeleteBehavior.Restrict);



        //}
    }
}