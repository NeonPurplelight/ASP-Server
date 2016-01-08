namespace aspserver_sfb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inserats", "Bild", c => c.Byte(nullable: false));
            DropColumn("dbo.Inserats", "BildNr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inserats", "BildNr", c => c.Int(nullable: false));
            DropColumn("dbo.Inserats", "Bild");
        }
    }
}
