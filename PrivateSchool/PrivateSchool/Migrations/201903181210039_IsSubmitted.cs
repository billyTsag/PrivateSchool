namespace PrivateSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSubmitted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAssignments", "IsSubmitted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentAssignments", "IsSubmitted");
        }
    }
}
