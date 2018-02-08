using AtividadePOO.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadePOO
{
    public class DataContext : DbContext
    {
        public DbSet<Conta> Contas{get;set;}
        public DbSet<ContaConrrente> ContasCorrente{get;set;}
        public DbSet<ContaPoupanca> ContasPoupanca{get;set;}
        public DbSet<ContaTitular> ContasTitular{get;set;}
        public DbSet<Titular> Titular{get;set;}
        public DbSet<Agencia> Agencias { get; set; }
        
        public DbSet<Banco> Bancos { get; set; }
        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Lp2;User Id=sa;Password=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Adição de chaves compostas
            modelBuilder.Entity<ContaTitular>().HasKey(ct => new { ct.ContaId, ct.TitularId});

            //Adição de chaves unicas
            modelBuilder.Entity<Conta>().HasIndex(c => c.Numero).IsUnique(true);
            modelBuilder.Entity<Titular>().HasIndex(t => t.Cpf).IsUnique(true);
        }

    }
}