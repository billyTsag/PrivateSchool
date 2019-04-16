namespace PrivateSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerEnrollment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainerCourses", "Trainer_ID", "dbo.Trainers");
            DropForeignKey("dbo.TrainerCourses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_ID" });
            DropIndex("dbo.TrainerCourses", new[] { "Course_ID" });
            CreateTable(
                "dbo.TrainerEnrollments",
                c => new
                    {
                        TrainerID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => new { t.TrainerID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerID, cascadeDelete: true)
                .Index(t => t.TrainerID)
                .Index(t => t.CourseID);
            
            DropTable("dbo.TrainerCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Trainer_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_ID, t.Course_ID });
            
            DropForeignKey("dbo.TrainerEnrollments", "TrainerID", "dbo.Trainers");
            DropForeignKey("dbo.TrainerEnrollments", "CourseID", "dbo.Courses");
            DropIndex("dbo.TrainerEnrollments", new[] { "CourseID" });
            DropIndex("dbo.TrainerEnrollments", new[] { "TrainerID" });
            DropTable("dbo.TrainerEnrollments");
            CreateIndex("dbo.TrainerCourses", "Course_ID");
            CreateIndex("dbo.TrainerCourses", "Trainer_ID");
            AddForeignKey("dbo.TrainerCourses", "Course_ID", "dbo.Courses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TrainerCourses", "Trainer_ID", "dbo.Trainers", "ID", cascadeDelete: true);
        }
    }
}
