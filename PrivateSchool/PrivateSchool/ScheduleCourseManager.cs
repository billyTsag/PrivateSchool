using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class ScheduleCourseManager
    {
        public static void CreateSchedule(int courseID, DateTime startDate, DateTime endDate)
        {            
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Course course = db.Courses.Find(courseID);
                if (course == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                course.StartDate = startDate;
                course.EndDate = endDate;
                db.SaveChanges();
            }            
        }

        public static void UpdateSchedule(int courseID, DateTime startDate, DateTime endDate)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Course course = db.Courses.Find(courseID);
                if (course == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                course.StartDate = startDate;
                course.EndDate = endDate;
                db.SaveChanges();
            }
        }

        public static void DeleteSchedule(int courseID)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Course course = db.Courses.Find(courseID);
                if (course == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }                
                //course.StartDate = null;
                //course.EndDate = null;
                db.SaveChanges();
            }            
        }

        public static List<Course> GetAllSchedules()
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.Courses.ToList();
            }
        }
    }
}
