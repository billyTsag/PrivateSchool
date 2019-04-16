using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class AssignmentCourseManager
    {
        public static void CreateAssignmentPerCourse(int assignmentID, int courseID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Assignment assignment = db.Assignments.Find(assignmentID);
                Course course = db.Courses.Find(courseID);
                if (assignment == null || course == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                assignment.Course = course;
                db.SaveChanges();
            }
            return; 
        }

        public static void GetAllAssignmentsPerCourse()
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {

            }
        }

        public static void DeleteAssignmentPerCourse(int assignmentID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Assignment assignment = db.Assignments.Find(assignmentID);                
                assignment.Course = null;
                db.SaveChanges();
            }
            return;
        }

        public static void CreateAssignmentPerStudent(int studentID, int assignmentID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Student student = db.Students.Find(studentID);
                Assignment assignment = db.Assignments.Find(assignmentID);
                if (student == null || assignment == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                StudentAssignments studentAssignments = new StudentAssignments()
                {
                    Student = student,
                    Assignment = assignment
                };
                db.StudentAssignments.Add(studentAssignments);
                db.SaveChanges();
            }
        }

        public static void DeleteAssignmentPerStudent(int studentID, int assignmentID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                StudentAssignments studentAssignments = db.StudentAssignments.Find(studentID, assignmentID);
                if (studentAssignments == null)
                {
                    return;
                }
                db.StudentAssignments.Remove(studentAssignments);
                db.SaveChanges();
            }
        }
                

        public static void DateSubmissionOfAssignment(int studentID)
        {           
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                var query = db.StudentAssignments.Where(x => x.StudentID == studentID).ToList();
                foreach (var assignment in query)
                {
                    Console.WriteLine($"{assignment}"); // ama borousa na valw assignment.Assignment.Submission ola tha tan boba
                    //if (DateTime.Now < assignment.Assignment.Submission)
                   
                }
            }            
        }

        public static void ScheduleOfStudent(int studentID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                var query = db.StudentEnrollements.Where(x => x.StudentID == studentID).ToList();
                foreach (var course in query)
                {
                    Console.WriteLine($"{course}"); // ama borousa na valw course.Course.StartDate ke adistixa EndDate ola tha tan boba
                    //if (DateTime.Now < course.Course.EndDate)
                }
            }
        }

        public static void StudentSubmitAssignment(int studentID, int assignmentID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                StudentAssignments studentAssignments = db.StudentAssignments.Find(studentID, assignmentID);
                studentAssignments.IsSubmitted = true;
                db.SaveChanges();
            }
        }

    }
}
