using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Models;

namespace LogisticaHospitalaria_Backend.Data
{
    public class LogisticaHospitalariaContext : DbContext
    {
        public LogisticaHospitalariaContext(DbContextOptions<LogisticaHospitalariaContext> options) : base(options) { }

        // Tablas simplificadas y normalizadas
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PedidoAutomatico> PedidoAutomaticos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Departamento: El código debe ser único (para el match con la API externa)
            modelBuilder.Entity<Departamento>()
                .HasIndex(d => d.Codigo)
                .IsUnique();

            // 2. Relación Usuario -> Departamento
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Departamento)
                .WithMany(d => d.Usuarios)
                .HasForeignKey(u => u.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict); // No borra depto si hay usuarios

            // 3. Relación Pedido -> Departamento
            modelBuilder.Entity<PedidoAutomatico>()
                .HasOne(p => p.Departamento)
                .WithMany(d => d.Pedidos)
                .HasForeignKey(p => p.DepartamentoId)
                .OnDelete(DeleteBehavior.Cascade); // Si borras un depto, se van sus pedidos

            // 4. Relación Detalle -> Pedido
            modelBuilder.Entity<PedidoDetalle>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade); // Si borras el pedido, se van los items
        }
    }
}