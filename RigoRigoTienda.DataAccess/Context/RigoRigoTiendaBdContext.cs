using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RigoRigoTienda.DataAccess.Context
{
    public partial class RigoRigoTiendaBdContext : DbContext
    {
        public RigoRigoTiendaBdContext()
        {
        }

        public RigoRigoTiendaBdContext(DbContextOptions<RigoRigoTiendaBdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=RigoRigoTiendaBd; User Id=UserRigoRigo; Password=123456; Encrypt=Yes; TrustServerCertificate=Yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.DetallePedido)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetallePe__Pedid__3B75D760");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallePedido)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetallePe__Produ__3C69FB99");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.PedidoId)
                    .HasName("PK__Pedidos__09BA143094C95398");

                entity.Property(e => e.CedulaCliente)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DireccionEntrega)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProductoId)
                    .HasName("PK__Producto__A430AEA3FC26AA9A");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
