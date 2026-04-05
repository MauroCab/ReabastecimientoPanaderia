using Microsoft.EntityFrameworkCore;
using ReabastecimientoPanaderia.DB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data
{
    internal class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<TipoProducto> TiposProducto { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Renglon> Renglones { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de relaciones y restricciones
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.TipoProducto)
                .WithMany(tp => tp.Productos)
                .HasForeignKey(p => p.TipoProductoID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Renglon>()
                .HasOne(r => r.ProductoSolicitado)
                .WithMany()
                .HasForeignKey(r => r.ProductoSolicitadoID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Renglon>()
                .HasOne(r => r.Pedido)
                .WithMany(p => p.Renglones)
                .HasForeignKey(r => r.PedidoID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
