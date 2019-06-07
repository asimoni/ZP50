namespace ZP50.Core.Migrations
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.History;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZP50.Core.DataLayer.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "ZP50.Core.DataLayer.OratorioContext";
        }

        protected override void Seed(ZP50.Core.DataLayer.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }






}
