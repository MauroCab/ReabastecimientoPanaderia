using Microsoft.EntityFrameworkCore;
using ReabastecimientoPanaderia.DB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.DB.Data
{
    public class Context : DbContext
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
            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasMany(tp => tp.Productos)
                    .WithOne(p => p.TipoProducto)
                    .HasForeignKey(p => p.TipoProductoID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(tp => tp.Codigo)
                                .HasMaxLength(3)
                                .IsRequired();
                entity.Property(tp => tp.Nombre)
                                .HasMaxLength(50)
                                .IsRequired();

                entity.HasIndex(tp => tp.Codigo).IsUnique();
                entity.HasIndex(tp => tp.Nombre).IsUnique();
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasOne(p => p.TipoProducto)
                .WithMany(tp => tp.Productos)
                .HasForeignKey(p => p.TipoProductoID)
                .OnDelete(DeleteBehavior.Restrict);

                entity.Property(p => p.Nombre)
                                .HasMaxLength(100)
                                .IsRequired();

                entity.Property(p => p.TipoProductoID).IsRequired();

                entity.HasIndex(p => p.Nombre).IsUnique();
                entity.HasIndex(p => new { p.TipoProductoID, p.Nombre }).IsUnique();


            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(p => p.FechaYHora)
                                .IsRequired();

                entity.HasIndex(p => p.FechaYHora);
            });

            modelBuilder.Entity<Renglon>(entity =>
            {
                entity.HasOne(r => r.Pedido)
                    .WithMany(p => p.Renglones)
                    .HasForeignKey(r => r.PedidoID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.ProductoSolicitado)
                .WithMany()
                .HasForeignKey(r => r.ProductoSolicitadoID)
                .OnDelete(DeleteBehavior.SetNull);

                entity.Property(r => r.CantidadSolicitada)
                                .IsRequired();

                entity.HasIndex(r => new { r.PedidoID, r.ProductoSolicitadoID })
                                .IsUnique();
            });
        }
    }
}
