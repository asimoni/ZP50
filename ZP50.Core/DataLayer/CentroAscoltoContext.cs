using System.Data.Entity;
using ZP50.Core.CentroAscolto;
using ZP50.Core.Migrations;
using ZP50.Core.Oratorio;

namespace ZP50.Core.DataLayer
{
    public class CentroAscoltoContext : DbContext
    {
        public CentroAscoltoContext() : base()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CentroAscoltoContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CentroAscoltoContext, CentroAscoltoConfiguration>());

        }

        public DbSet<NucleoFamiliare> NucleiFamiliari { get; set; }
        public DbSet<Persona> Persone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            //modelBuilder.HasDefaultSchema("Admin");

            //Map entity to table
            modelBuilder.Entity<Partecipante>().ToTable("Partecipanti");
            modelBuilder.Entity<Presenza>().ToTable("Presenze");
            modelBuilder.Entity<QuotaPartecipazione>().ToTable("QuotePartecipazione");
        }

        public DbSet<Contatto> Contatti { get; set; }

        public DbSet<ZP50.Core.Oratorio.QuotaPartecipazione> QuotePartecipazione { get; set; }
        public DbSet<ZP50.Core.Oratorio.QuotaAcquistata> QuoteAcquistate { get; set; }

        public System.Data.Entity.DbSet<ZP50.Core.CentroAscolto.SchedaIncontro> SchedaIncontroes { get; set; }
    }
}
