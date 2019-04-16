namespace PrivateSchool
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using PrivateSchool.Models;

    public class PrivateSchoolContext : DbContext
    {
        // Your context has been configured to use a 'PrivateSchoolContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PrivateSchool.PrivateSchoolContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PrivateSchoolContext' 
        // connection string in the application configuration file.
        public PrivateSchoolContext()
            : base("name=PrivateSchoolContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<StudentEnrollement> StudentEnrollements { get; set; }
        public virtual DbSet<TrainerEnrollment> TrainerEnrollments { get; set; }
        public virtual DbSet<StudentAssignments> StudentAssignments { get; set; }   
        public virtual DbSet<HeadMaster> HeadMasters { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}