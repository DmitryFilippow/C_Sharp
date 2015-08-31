namespace GameCheatsDBSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameCheats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cheats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        GameName = c.String(),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cheats");
        }
    }
}
