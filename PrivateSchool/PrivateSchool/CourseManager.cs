using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class CourseManager
    {
        public static int CreateCourse(string title, string stream, string type)
        {
            Course course = new Course()
            {
                Title = title,
                Stream = stream,
                Type = type,                             
            };
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
            return course.ID;
        }

        public static List<Course> GetAllCourses()
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.Courses.ToList();
            }
        }

        public static Course GetCourse(int id)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.Courses.Find(id);
            }
        }

        public static void DeleteCourse(int id)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                db.Courses.Remove(course);
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, string title, string stream, string type)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                course.Title = title;
                course.Stream = stream;
                course.Type = type;                
                db.SaveChanges();
            }
        }
    }
}
