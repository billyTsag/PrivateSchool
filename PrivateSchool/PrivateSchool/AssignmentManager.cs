using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class AssignmentManager
    {
        public static int CreateAssignment(string title, DateTime submission)
        {   
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Assignment assignment = new Assignment()
                {
                    Title = title,
                    Submission = submission,
                };
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return assignment.ID;
            }
            
        }

        public static List<Assignment> GetAllAssignments()
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.Assignments.ToList();
            }
        }        

        public static void DeleteAssignment(int id)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return;
                }
                db.Assignments.Remove(assignment);
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment(int id, string title, DateTime submission)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                assignment.Title = title;
                assignment.Submission = submission;                
                db.SaveChanges();
            }
        }
    }
}
