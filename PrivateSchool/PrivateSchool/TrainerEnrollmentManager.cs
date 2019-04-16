using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class TrainerEnrollmentManager
    {
        public static void EnrollTrainer(int trainerID, int courseID, string subject)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                Course course = db.Courses.Find(courseID);
                if (trainer == null || course == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                TrainerEnrollment trainerEnrollment = new TrainerEnrollment()
                {
                    Trainer = trainer,
                    Course = course,
                    Subject = subject
                };
                db.TrainerEnrollments.Add(trainerEnrollment);
                db.SaveChanges();
            }
        }

        public static List<TrainerEnrollment> GetAllEnrolledTrainers()
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.TrainerEnrollments.ToList();
            }
        }

        public static void UpdateEnrolledTrainer(int trainerID, int courseID, string subject)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                TrainerEnrollment trainerEnrollment = db.TrainerEnrollments.Find(trainerID, courseID);
                if (trainerEnrollment == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                trainerEnrollment.Subject = subject;
                db.SaveChanges();
            }
        }

        public static void DeleteEnrolledTrainer(int trainerID, int courseID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                TrainerEnrollment trainerEnrollment = db.TrainerEnrollments.Find(trainerID, courseID);
                if (trainerEnrollment == null)
                {
                    return;
                }
                db.TrainerEnrollments.Remove(trainerEnrollment);
                db.SaveChanges();
            }
        }

        public static List<TrainerEnrollment> GetAllCoursesOfTrainer(int trainerID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);                
                return db.TrainerEnrollments.Where(x => x.TrainerID == trainer.ID).ToList();
            }
        }

        public static List<StudentEnrollement> GetAllEnrolledStudentsOfTrainer(int trainerID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                var query = from te in db.TrainerEnrollments
                            where te.TrainerID == trainer.ID
                            join c in db.Courses on te.CourseID equals c.ID
                            join se in db.StudentEnrollements on c.ID equals se.CourseID
                            where te.CourseID == se.CourseID
                            orderby te.CourseID
                            select se;
                return query.ToList();
            }
        }
        
        public static List<StudentAssignments> ViewAssignmentsPerStudent(int trainerID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                var query = from te in db.TrainerEnrollments
                            where te.TrainerID == trainer.ID
                            join c in db.Courses on te.CourseID equals c.ID
                            join a in db.Assignments on c.ID equals a.Course.ID
                            join sa in db.StudentAssignments on a.ID equals sa.AssignmentID
                            select sa;
                return query.ToList();
            }
        }
        
        public static void MarkAssingmentPerStudent(int trainerID, int studentID, int assignmentID, int oralMark, int totalMark)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                Student student = db.Students.Find(studentID);
                Assignment assignment = db.Assignments.Find(assignmentID);
                StudentAssignments studentAssignments = db.StudentAssignments.Find(studentID, assignmentID);
                if (studentAssignments == null)
                {
                    Console.WriteLine("Entity does not exist!\n");
                    return;
                }
                studentAssignments.OralMark = oralMark;
                studentAssignments.TotalMark = totalMark;
                db.SaveChanges();
            }
            
        }
    }
}
