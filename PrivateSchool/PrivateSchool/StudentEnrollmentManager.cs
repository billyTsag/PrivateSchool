using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class StudentEnrollmentManager
    {
        public static void EnrollStudent(int studentID, int courseID, int tuitionFees)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Student student = db.Students.Find(studentID);
                Course course = db.Courses.Find(courseID);
                if (student == null || course == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                StudentEnrollement studentEnrollement = new StudentEnrollement()
                {
                    Student = student,
                    Course = course,
                    TuitionFees = tuitionFees
                };
                db.StudentEnrollements.Add(studentEnrollement);
                db.SaveChanges();
            }
        }

        public static List<StudentEnrollement> GetAllEnrolledStudents()
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.StudentEnrollements.ToList();
            }
        }

        public static void UpdateEnrolledStudent(int studentID, int courseID, int tuitionFees)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                StudentEnrollement studentEnrollement = db.StudentEnrollements.Find(studentID, courseID);
                if (studentEnrollement == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                studentEnrollement.TuitionFees = tuitionFees;

                db.SaveChanges();
            }
        }

        public static void DeleteEnrolledStudent(int studentID, int courseID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                StudentEnrollement studentEnrollement = db.StudentEnrollements.Find(studentID, courseID);
                if (studentEnrollement == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                db.StudentEnrollements.Remove(studentEnrollement);
                db.SaveChanges();
            }
        }

        public static void SubmitAnAssignment(int studentID, int assignmentID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Student student = db.Students.Find(studentID);
                Assignment assignment = db.Assignments.Find(assignmentID);
                StudentAssignments studentAssignment = db.StudentAssignments.Find(studentID, assignmentID);
                if (studentAssignment == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                studentAssignment.IsSubmitted = true;
                db.SaveChanges();
            }
        }        
    }
}
