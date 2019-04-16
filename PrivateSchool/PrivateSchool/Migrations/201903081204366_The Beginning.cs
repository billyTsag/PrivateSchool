namespace PrivateSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheBeginning : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Submission = c.DateTime(nullable: false),
                        Course_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Stream = c.String(),
                        Type = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Course_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.Course_ID })
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.Student_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Trainer_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_ID, t.Course_ID })
                .ForeignKey("dbo.Trainers", t => t.Trainer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.Trainer_ID)
                .Index(t => t.Course_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.TrainerCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.TrainerCourses", "Trainer_ID", "dbo.Trainers");
            DropForeignKey("dbo.StudentCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Courses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.TrainerCourses", new[] { "Course_ID" });
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_ID" });
            DropIndex("dbo.StudentCourses", new[] { "Course_ID" });
            DropIndex("dbo.StudentCourses", new[] { "Student_ID" });
            DropIndex("dbo.Courses", new[] { "Course_ID" });
            DropIndex("dbo.Assignments", new[] { "Course_ID" });
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Trainers");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
