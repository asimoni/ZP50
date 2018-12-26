using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZP50.Core.Migrations;
using ZP50.Core.Oratorio;

namespace ZP50.Core.DataLayer
{

        public class OratorioContext : DbContext
    {
        public OratorioContext() : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OratorioContext, Configuration>());

        }

        public DbSet<Partecipante> Partecipanti { get; set; }
        public DbSet<Presenza> Presenze { get; set; }

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

    }
}
