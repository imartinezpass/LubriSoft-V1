using LubriSoft.Entities;
using Microsoft.EntityFrameworkCore;

namespace LubriSoft.Data
{
    public class LubriSoftDataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Aceite> Aceites { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Mecanica> Mecanica { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .HasOne(x => x.Aceite)
                .WithMany()
                .HasForeignKey(x => x.AceiteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne(x => x.Vehiculo)
                .WithMany()
                .HasForeignKey(x => x.Patente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mecanica>()
                .HasOne(x => x.Vehiculo)
                .WithMany()
                .HasForeignKey(x => x.Patente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aceite>()
                .HasOne(x => x.Marca)
                .WithMany()
                .HasForeignKey(x => x.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(x => x.Fabricante)
                .WithMany()
                .HasForeignKey(x => x.FabricanteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(x => x.Modelo)
                .WithMany()
                .HasForeignKey(x => x.ModeloId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Modelo>()
                .HasOne(x => x.Fabricante)
                .WithMany()
                .HasForeignKey(x => x.FabricanteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}