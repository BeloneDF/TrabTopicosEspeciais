using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().HasKey(p => p.Id);

            modelBuilder.Entity<Venda>().HasKey(p => p.Id);
            modelBuilder.Entity<Venda>().HasOne(p => p.Livro).WithMany().HasForeignKey(p => p.CodigoLivro);
            modelBuilder.Entity<Venda>().HasOne(p => p.Funcionario).WithMany().HasForeignKey(p => p.CodigoFuncionario);

            modelBuilder.Entity<Funcionario>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
