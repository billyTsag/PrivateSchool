namespace PrivateSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class headmastertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeadMasters",
                c => new
                    {
                        HeadMasterID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.HeadMasterID);            
        }
        
        public override void Down()
        {
            DropTable("dbo.HeadMasters");
        }
    }
}
