using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Sistema_de_Vendas.Models;

namespace Projeto_Sistema_de_Vendas.Context
{
    public class SistemaVendaContext : DbContext
    {
        public DbSet<Vendedor> Vendedores {get;set;}
        public DbSet<Venda> Vendas {get;set;}
        public DbSet<Produto> Produtos {get;set;}
        public DbSet<VendaProduto> VendaProdutos {get;set;}
        public DbSet<Cliente> Clientes {get;set;}
        
        public SistemaVendaContext(DbContextOptions<SistemaVendaContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<VendaProduto>()
                .HasKey(vp => new { vp.VendaId, vp.ProdutoId });

            modelBuilder.Entity<VendaProduto>()
                .HasOne(vp => vp.Venda)
                .WithMany(v => v.VendaProdutos)
                .HasForeignKey(vp => vp.VendaId);

            modelBuilder.Entity<VendaProduto>()
                .HasOne(vp => vp.Produto)
                .WithMany(p => p.VendaProdutos)
                .HasForeignKey(vp => vp.ProdutoId);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Vendedor)
                .WithMany(vd => vd.Vendas)
                .HasForeignKey(v => v.VendedorId);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Vendas)
                .HasForeignKey(v => v.ClienteId);
        }
    }
}