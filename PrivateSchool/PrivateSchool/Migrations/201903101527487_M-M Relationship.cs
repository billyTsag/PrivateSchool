namespace PrivateSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MMRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "Student_ID" });
            DropIndex("dbo.StudentCourses", new[] { "Course_ID" });
            CreateTable(
                "dbo.StudentEnrollements",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        TuitionFees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
            DropTable("dbo.StudentCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.Course_ID });
            
            DropForeignKey("dbo.StudentEnrollements", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentEnrollements", "CourseID", "dbo.Courses");
            DropIndex("dbo.StudentEnrollements", new[] { "CourseID" });
            DropIndex("dbo.StudentEnrollements", new[] { "StudentID" });
            DropTable("dbo.StudentEnrollements");
            CreateIndex("dbo.StudentCourses", "Course_ID");
            CreateIndex("dbo.StudentCourses", "Student_ID");
            AddForeignKey("dbo.StudentCourses", "Course_ID", "dbo.Courses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students", "ID", cascadeDelete: true);
        }
    }
}
