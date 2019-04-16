namespace PrivateSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backtobasics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Username", c => c.String());
            AddColumn("dbo.Students", "Password", c => c.String());
            AddColumn("dbo.Trainers", "Username", c => c.String());
            AddColumn("dbo.Trainers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "Password");
            DropColumn("dbo.Trainers", "Username");
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "Username");
        }
    }
}
