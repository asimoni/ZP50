using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZP50.Core.Migrations;
using ZP50.Core.Oratorio;
using ZP50.Core.CentroAscolto;

namespace ZP50.Core.DataLayer
{

    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Configuration>());

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("dbo");

            //Map entity to table
            modelBuilder.Entity<Partecipante>().ToTable("Partecipanti");
            modelBuilder.Entity<Presenza>().ToTable("Presenze");
            modelBuilder.Entity<QuotaPartecipazione>().ToTable("QuotePartecipazione");


            modelBuilder.Entity<NucleoFamiliare>().ToTable("NucleiFamiliari");
            modelBuilder.Entity<Persona>().ToTable("Persone");
            modelBuilder.Entity<SchedaIncontro>().ToTable("SchedeIncontri");

        }

        #region Oratorio
        public DbSet<Contatto> Contatti { get; set; }    
        public DbSet<QuotaPartecipazione> QuotePartecipazione { get; set; }
        public DbSet<QuotaAcquistata> QuoteAcquistate { get; set; }
        public DbSet<Partecipante> Partecipanti { get; set; }
        public DbSet<Presenza> Presenze { get; set; }
        #endregion

        #region CentroAscolto

        public DbSet<NucleoFamiliare> NucleiFamiliari { get; set; }
        public DbSet<Persona> Persone { get; set; }
        public DbSet<SchedaIncontro> SchedaIncontroes { get; set; }

        #endregion
    }
}
