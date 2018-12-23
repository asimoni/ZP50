namespace ZP50.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Partecipanti",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cognome = c.String(),
                        DataNascita = c.String(),
                        Indirizzo_Via = c.String(),
                        Indirizzo_Civico = c.String(),
                        Indirizzo_Comune = c.String(),
                        Indirizzo_Cap = c.String(),
                        Indirizzo_Provincia = c.String(),
                    CodiceIdentificativo = c.String(),
                    Annotazioni = c.String(),
                })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recapitoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoRecapito = c.String(),
                        Valore = c.String(),
                        Note = c.String(),
                        Partecipante_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Partecipanti", t => t.Partecipante_ID)
                .Index(t => t.Partecipante_ID);
            
            CreateTable(
                "dbo.Presenze",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IscrizioneID = c.Int(nullable: false),
                        Giorno = c.DateTime(nullable: false),
                        Ingresso = c.DateTime(nullable: false),
                        Uscita = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recapitoes", "Partecipante_ID", "dbo.Partecipanti");
            DropIndex("dbo.Recapitoes", new[] { "Partecipante_ID" });
            DropTable("dbo.Presenze");
            DropTable("dbo.Recapitoes");
            DropTable("dbo.Partecipanti");
        }
    }
}
