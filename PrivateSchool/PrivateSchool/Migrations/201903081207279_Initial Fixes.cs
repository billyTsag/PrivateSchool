namespace PrivateSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "Course_ID" });
            DropColumn("dbo.Courses", "Course_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Course_ID", c => c.Int());
            CreateIndex("dbo.Courses", "Course_ID");
            AddForeignKey("dbo.Courses", "Course_ID", "dbo.Courses", "ID");
        }
    }
}
