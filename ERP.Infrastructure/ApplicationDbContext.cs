using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedido>()
                .HasOne(i => i.Produto)
                .WithMany()
                .HasForeignKey(i => i.ProdutoId);

            modelBuilder.Entity<ItemPedido>()
                .HasOne(i => i.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.PedidoId);
        }
    }

}
