using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class StudentManager
    {
        public static int CreateStudent(string firstName, string lastName, DateTime dateOfBirth)
        {
            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
            return student.ID;
        }

        public static List<Student> GetAllStudents()
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.Students.ToList();   
            }
        }

        public static Student GetStudent(int id)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.Students.Find(id);
            }
        }

        public static void DeleteStudent(int id)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }

        public static void UpdateStudent(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                student.FirstName = firstName;
                student.LastName = lastName;
                student.DateOfBirth = dateOfBirth;
                db.SaveChanges();
            }
        }

        public static void CreateAccount(int studentID, string username, string password)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Student student = db.Students.Find(studentID);
                if (student == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                student.Username = username;
                student.Password = password;
                db.SaveChanges();
            }
        }

        public static Student FindPassword(string username)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                var query = db.Students.Where(s => s.Username == username).FirstOrDefault<Student>();
                return query;
            }
        }

    }
}
