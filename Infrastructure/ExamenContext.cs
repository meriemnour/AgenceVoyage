using ApplicationCore.Domain;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ExamenContext: DbContext
    {
        //DBSet
        public DbSet<Activite> Activites { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Conseiller> Conseillers { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        //OnConfiguring

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AgenceVoyageDB;Integrated Security=true;
              MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
          
        }
        //OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1ere méthode
            //implémentation directe de la classe zone 
            //--> modelBuilder.Entity<Activite>().OwnsOne(a => a.Zone);
            
            
            //2eme methode
            //configuration à travers une classe de configuartion
            modelBuilder.ApplyConfiguration(new ActiviteConfiguration());

            //Configurer la table porteuse
            modelBuilder.Entity<Reservation>().HasKey(r => new { r.PackFK, r.ClientFK });

            //Configurer one to many
            modelBuilder.Entity<Client>().HasOne(cl=>cl.Conseiller)
                .WithMany(c=>c.Clients).HasForeignKey(cl=>cl.ConserillerFK).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        //ConfigureConventions
    }
}
