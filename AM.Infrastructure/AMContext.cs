using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var _connectionString = @"server=localhost;database=LivNasfiEya;uid=root;password=;";
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivreurConfig());
            modelBuilder.ApplyConfiguration(new ColisConfig());
            //modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.Entity<Camion>().ToTable("Camion");
            modelBuilder.Entity<Voiture>().ToTable("Voiture");
            //modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder.Properties<DateTime>()
            //    .HaveColumnType("date");
        }


        public DbSet<Livreur> Livreur { get; set; }
        public DbSet<Vehicule> Vehicule { get; set; }
        public DbSet<Colis> Colis { get; set; }
        public DbSet<Client> Client { get; set; }
        //public DbSet<Staff> Staff { get; set; }

    }
}
