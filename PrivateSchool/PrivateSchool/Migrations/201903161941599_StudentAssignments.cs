namespace PrivateSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAssignments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAssignments",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        AssignmentID = c.Int(nullable: false),
                        OralMark = c.Int(nullable: false),
                        TotalMark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.AssignmentID })
                .ForeignKey("dbo.Assignments", t => t.AssignmentID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.AssignmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAssignments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssignments", "AssignmentID", "dbo.Assignments");
            DropIndex("dbo.StudentAssignments", new[] { "AssignmentID" });
            DropIndex("dbo.StudentAssignments", new[] { "StudentID" });
            DropTable("dbo.StudentAssignments");
        }
    }
}
