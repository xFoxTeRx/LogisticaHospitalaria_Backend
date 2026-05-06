// Data/LogisticaHospitalariaContext.cs
using LogisticaHospitalaria_Backend.Models;
using LogisticaHospitalaria_Backend.Models.HospitalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticaHospitalaria_Backend.Data
{
    public class LogisticaHospitalariaContext : DbContext
    {
        public LogisticaHospitalariaContext(DbContextOptions<LogisticaHospitalariaContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PedidoAutomatico> PedidoAutomaticos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }

        public DbSet<Cama> Camas { get; set; }
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

            modelBuilder.Entity<Cama>().HasData(
                new Cama { Id = 1, Departamento = "Emergencias", CantidadCamas = 20 },
                new Cama { Id = 2, Departamento = "Pediatría", CantidadCamas = 15 },
                new Cama { Id = 3, Departamento = "UCI", CantidadCamas = 10 },
                new Cama { Id = 4, Departamento = "Cirugía", CantidadCamas = 25 },
                new Cama { Id = 5, Departamento = "Maternidad", CantidadCamas = 18 }
            );
        }

    }
}