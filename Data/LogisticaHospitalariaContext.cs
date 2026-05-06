// Data/LogisticaHospitalariaContext.cs
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Models;

namespace LogisticaHospitalaria_Backend.Data
{
    public class LogisticaHospitalariaContext : DbContext
    {
        public LogisticaHospitalariaContext(DbContextOptions<LogisticaHospitalariaContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PedidoAutomatico> PedidoAutomaticos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departamento>()
                .HasIndex(d => d.Codigo)
                .IsUnique();

            modelBuilder.Entity<PedidoAutomatico>()
                .HasOne(p => p.Departamento)
                .WithMany(d => d.Pedidos)
                .HasForeignKey(p => p.DepartamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PedidoDetalle>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}